using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Collections;

namespace LanguagePlayer
{
    public partial class MainForm : Form
    {
        //要練習的單字陣列
        string[] arr;

        //目前要呈現的單字的index
        int i;

        //答對次數|常答對的就不用出現
        Hashtable htHitCount = new Hashtable();


        //將單字Label加入List方便控管
        List<MyLabel> list = new List<MyLabel>();
        List<MyLabel> removelist = new List<MyLabel>();

        //答對次數
        int hit = 0;

        //單字移動速度
        int intSpeed = 100;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            nudSpeed.Maximum = intSpeed - 1;
            timerMoveWords.Interval = intSpeed;

            //設定規則下拉選單
            SettingUsualPatten();

            //設定可下拉文件
            SetDocuments();

            //讀排除
            string exclude = $"{Application.StartupPath}\\exclude.txt";
            if (File.Exists(exclude)) {
                string strExclude = File.ReadAllText(exclude);
                strExclude = strExclude.Replace("\r\n\r\n", "\r\n").Replace("  "," ");
                txtExclude.Text = strExclude;
            }

            //讀內容
            string current = $"{Application.StartupPath}\\current.txt";
            if (File.Exists(current))
                txtSource.Text = File.ReadAllText(current);

            ProcessInputText();
        }


        void SetDocuments()
        {
            comboDocs.Items.Clear();
            string path = $"{Application.StartupPath}\\docs\\";
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
                di.Create();
            comboDocs.Items.Add(new ComboboxItem("current", $"{Application.StartupPath}\\current.txt"));
            foreach (FileInfo fi in di.GetFiles("*.txt"))
                comboDocs.Items.Add(new ComboboxItem(fi.Name, fi.FullName));
        }

        void SettingUsualPatten() {
            comboPatten.Items.Add(new ComboboxItem("英文", "[A-z'\\-]{2,}"));
            comboPatten.Items.Add(new ComboboxItem("非英文", "[^A-z']"));

            comboPatten.SelectedIndex = 0;
            comboPatten.Text = ((ComboboxItem)comboPatten.SelectedItem).Value.ToString();
        }

        void ProcessInputText()
        {
            //來源資料
            string input = txtSource.Text;
            string pattern = comboPatten.Text;
            //pattern = "[A-z']{2,}";


            var mc = Regex.Matches(input, pattern)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray().Distinct().ToArray();

            //排除資料
            string path = $"{Application.StartupPath}\\exclude.txt";
            string[] exclude = new string[] { };
            if (File.Exists(path))
                exclude = File.ReadAllLines(path);


            List<string> list = new List<string>();
            foreach (var item in mc.Except(exclude))
            {
                //Console.WriteLine(item);
                list.Add(item);
            }

            arr = list.ToArray();
        }



        private void inputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e != null && e.KeyData == Keys.Escape) inputBox.Text = "";
            string key = inputBox.Text;
            foreach (var l in list)
            {
                if (l.Text.ToLower() == key.ToLower())
                {
                    Hitted(l);
                    return;
                }
            }
        }

        void Hitted(MyLabel l) {
            inputBox.Text = "";
            hit += 1;
            labHitCount.Text = $"共擊中:{hit}次";
            if (hit % 10 == 0)
                if (nudSpeed.Value < nudSpeed.Maximum)
                    nudSpeed.Value += 1;

            //累加答對次數
            if (htHitCount.ContainsKey(l.Text))
                htHitCount[l.Text] = (int)htHitCount[l.Text] + 1;
            else
                htHitCount[l.Text] = 1;

            if ((int)htHitCount[l.Text] > 100) {
                //列入排除文字
                AddExclude(l.Text);
            }

            //移除前先查到對應中文，再使用動畫讓內容消失
            string txt = GetMessage(l.Text);
            if(txt==l.Text) txt = GetMessage2(l.Text);
            l.Text = txt;
            l.ForeColor = Color.Red;
            l.Font = new Font(l.Font, FontStyle.Bold);
            removelist.Add(l);
        }

        void AddExclude(string text) {
            txtExclude.AppendText($"\r\n{text}");
            SaveExclude();
        }

        void SaveExclude()
        {
            try
            {
                string path = $"{Application.StartupPath}\\exclude.txt";
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(txtExclude.Text);
                sw.Close();
            }
            catch {; }
        }


        string GetFileMessage(string text)
        {
            string result = string.Empty;
            //讀內容
            string path = $"{Application.StartupPath}\\translate\\{text}.txt";
            if (File.Exists(path))
                result = File.ReadAllText(path);

            return result;
        }
        string GetMessage(string text)
        {
            string result = GetFileMessage(text);
            if (string.IsNullOrEmpty(result))
            {
                result = text;

                String url = $"http://translate.google.cn/translate_a/single?client=gtx&dt=t&dj=1&ie=UTF-8&sl=auto&tl=zh_TW&q={text}";
                try
                {

                    //byte[] postData = Encoding.GetEncoding("UTF-8").GetBytes(data);
                    //byte[] postData = Encoding.GetEncoding(EncodingName).GetBytes(data);
                    HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                    request.Method = "GET";  //方法
                    request.KeepAlive = true; //是否保持連線
                    request.ContentType = "application/x-www-form-urlencoded";

                    //using (Stream reqStream = request.GetRequestStream())
                    //{
                    //    reqStream.Write(postData, 0, postData.Length);
                    //}
                    string tmp = null;//取回的內容

                    using (WebResponse response = request.GetResponse())
                    {
                        StreamReader sr = new StreamReader(response.GetResponseStream());
                        tmp = sr.ReadToEnd();
                        sr.Close();

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        Translate translate = js.Deserialize<Translate>(tmp);// //反序列化
                        result = translate.sentences[0].trans;
                        if (!string.IsNullOrEmpty(result) && result != text)
                        {
                            string path = $"{Application.StartupPath}\\translate\\{text}.txt";
                            (new FileInfo(path)).Directory.Create();
                            File.WriteAllText(path, result);
                        }
                    }
                }
                catch(Exception ex)
                {
                    labMessage.Text = ex.Message;
                }
            }
            return result;
        }
        string GetMessage2(string text)
        {
            string result = GetFileMessage(text);
            if (string.IsNullOrEmpty(result))
            {
                result = text;

                String url = $"http://fanyi.youdao.com/translate?&doctype=json&type=AUTO&i={text}";
                try
                {

                    //byte[] postData = Encoding.GetEncoding("UTF-8").GetBytes(data);
                    //byte[] postData = Encoding.GetEncoding(EncodingName).GetBytes(data);
                    HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                    request.Method = "GET";  //方法
                    request.KeepAlive = true; //是否保持連線
                    request.ContentType = "application/x-www-form-urlencoded";

                    //using (Stream reqStream = request.GetRequestStream())
                    //{
                    //    reqStream.Write(postData, 0, postData.Length);
                    //}
                    string tmp = null;//取回的內容

                    using (WebResponse response = request.GetResponse())
                    {
                        StreamReader sr = new StreamReader(response.GetResponseStream());
                        tmp = sr.ReadToEnd();
                        sr.Close();
                        tmp = tmp.Replace("[[", "[").Replace("]]","]");

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        Youdao translate = js.Deserialize<Youdao>(tmp);// //反序列化
                        result = translate.translateResult[0].tgt;
                        if (!string.IsNullOrEmpty(result) && result != text)
                        {
                            string path = $"{Application.StartupPath}\\translate\\{text}.txt";
                            (new FileInfo(path)).Directory.Create();
                            File.WriteAllText(path, result);
                        }
                    }
                }
                catch(Exception ex)
                {
                    labMessage.Text = ex.Message;
                }
            }
            return result;
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            ProcessInputText();
            //存內容
            string path = $"{Application.StartupPath}\\current.txt";
            File.WriteAllText(path, txtSource.Text);
        }



        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            timerMoveWords.Interval = intSpeed -Convert.ToInt32( nudSpeed.Value);
        }

        private void comboPatten_TextChanged(object sender, EventArgs e)
        {
            ProcessInputText();
        }

        private void comboPatten_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboPatten.Text =$"{comboPatten.SelectedValue}";
        }

        private void cbPause_Click(object sender, EventArgs e)
        {
            bool pause = !cbPause.Checked;
            timerAddWord.Enabled = pause;
            timerMoveWords.Enabled = pause;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            foreach (var l in list) //Hitted(l);//清除現有內容
                splitContainer1.Panel1.Controls.Remove(l);

            list.Clear();

            ProcessInputText();//重設文字
            labGameover.Visible = false;
            hit = 0;
            timerMoveWords.Enabled = true;
            timerAddWord.Enabled = true;
        }

        #region Timer
        /// <summary>
        /// 加入新字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerAddWord_Tick(object sender, EventArgs e)
        {
            //設定上限
            if (list.Count >= 10) return;

            MyLabel lab = new MyLabel();
            lab.AutoSize = true;
            lab.Font = new Font(lab.Font.FontFamily, 16);
            //lab.ForeColor = Color.FromArgb(80, 0, 0, 0);

            //防呆
            if (arr.Length == 0) return;

            i = i % arr.Length;
            lab.Text = arr[i];
            i++;
            splitContainer1.Panel1.Controls.Add(lab);
            //l的位置
            int w = splitContainer1.Panel1.Width - 100;
            lab.Location = new Point((new Random()).Next(w), 0);

            //加入列表方便控制
            list.Add(lab);
        }
        /// <summary>
        /// 移動文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMoveWords_Tick(object sender, EventArgs e)
        {
            foreach (var l in list)
            {
                //Color c = l.ForeColor;
                //if (c.A > 10)
                //    l.ForeColor = Color.FromArgb(c.A - 1, c);

                int y = l.Location.Y + 1;
                l.Location = new Point(l.Location.X, y);
                if (y + l.Font.Height > inputBox.Location.Y)
                {
                    //game over
                    labGameover.Text = "Game Over";
                    labGameover.Visible = true;
                    labGameover.Location = new Point(
                        splitContainer1.Panel1.Width / 2 - labGameover.Width / 2
                        , splitContainer1.Panel1.Height / 2 - labGameover.Height / 2);
                    timerMoveWords.Enabled = false;
                    timerAddWord.Enabled = false;
                }
            }

        }
        /// <summary>
        /// 移除文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRemove_Tick(object sender, EventArgs e)
        {
            foreach (MyLabel l in removelist)
            {
                Color c = l.ForeColor;
                if (c.A > 10)
                {
                    l.ForeColor = Color.FromArgb(c.A - 1, c);
                }
                else
                {
                    splitContainer1.Panel1.Controls.Remove(l);
                    list.Remove(l);
                }
            }
        }
        #endregion

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            foreach (var f in openFileDialog1.FileNames) {
                var fi = new FileInfo(f);
                string path = $"{Application.StartupPath}\\docs\\{fi.Name}";
                fi.CopyTo(path, true);
            }
            //重設下拉
            SetDocuments();
        }

        private void comboDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //讀內容
            string path = Convert.ToString(((ComboboxItem)comboDocs.SelectedItem).Value);
            if (File.Exists(path))
                txtSource.Text = File.ReadAllText(path);
        }

        private void txtExclude_Leave(object sender, EventArgs e)
        {
            //存檔
            SaveExclude();
        }

        private void txtAddExclude_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) {
                AddExclude(txtAddExclude.Text);
                inputBox.Text = txtAddExclude.Text;
                txtAddExclude.Text = string.Empty;
                inputBox_KeyUp(null, new KeyEventArgs(Keys.Enter));
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ComboboxItem(string text,string value) {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
