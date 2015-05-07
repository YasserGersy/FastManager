using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FastManager
{
    public partial class Form1 : Form
    {
        bool newExt = false;
        string cus_exten = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void brwsBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() != DialogResult.OK)
                return;
            txbxPath.Text = f.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sux = 0;
            int failed = 0;
            
            try
            {
                if (ExistedFolder() == false)
                    return;

                string[] files = Directory.GetFiles(txbxPath.Text, "*.*");

                string ext = "";
                if (chxNEWEXTEN.Checked)
                    ext = cus_exten;

                for (int i = 0; i < files.Length; i++)
                {
                    if (checkBoxsaveExt.Checked)
                        ext = GetExten(files[i]);
                    string NewFileName = CurentDir(files[i]) + s.Text + "_" + (i + 1).ToString() + ext;
                    if (files[i] == NewFileName)
                        continue;
                    try { 
                    File.Move(files[i], NewFileName);
                    sux++;
                    }
                    catch { failed++; }
                }
                MessageBox.Show("Renamed="+sux.ToString()+Environment.NewLine+"Failed="+failed.ToString(),"Result");
            }
            catch (Exception ex){ MessageBox.Show(ex.Message,"Error"); }
        }

        private string GetExten(string p)
        {
            try
            {
                string[] seps = p.Split(new char[] { '\\' });
                p = seps[seps.Length - 1];
                string[] sp = p.Split(new char[] { '.' });
                return "."+sp[sp.Length - 1];
            }
            catch { return ""; }
        }

        private string CurentDir(string p)
        {
            string res="";
            string[] d = p.Split(new char[] { '\\' });
            for (int i = 0; i < d.Length - 1; i++)
                res += (d[i] + "\\");
             
            return res;
            }

        private bool ExistedFolder()
        {
            return System.IO.Directory.Exists(txbxPath.Text);
        }

        private void txbxPath_TextChanged(object sender, EventArgs e)
        {
            CheckDirectory();
             timermain.Start();
            
        }
        int timerticks = 0;
        private void CheckDirectory()
        {
            timerticks = 0;
            int f = 0;
            int d = 0;
            int lnks = 0;
            int txt=0;
            int exe = 0;
            int media = 0;
            GpxOptions.Enabled = false;
            lblDirStatue.Text = "Not Existed Directory";
            if (ExistedFolder())
            {
                string[] fls = Directory.GetFiles(txbxPath.Text);
                f =fls.Length;
                d = Directory.GetDirectories(txbxPath.Text).Length;
                GpxOptions.Enabled = true;
                lblDirStatue.Text = "Existed Directory";
                foreach (string fp in fls)
                    if (IsShortCut(fp))
                        lnks++;
                    else if (IsText(fp))
                        txt++;
                    else if (isprogram(fp))
                        exe++;
                    else if (IsMedia(fp))
                        media++;


            }

            lblFiles.Text = f + " Files";
            lblDirs.Text = d + " Directories";
            lblshortcutsval.Text = lnks + " Shortcuts";
            lblText.Text = txt + " Text";
            lblEXEC.Text = exe+" Programs";
            lblmediaval.Text = media + " Media";
            
             
        }

        private bool IsMedia(string fp)
        {
            return (fp.Ends_with(".mp3") || fp.Ends_with(".mp4") || fp.Ends_with(".flv") || fp.Ends_with(".aud") || fp.Ends_with(".rmvb") || fp.Ends_with(".mkv") || fp.Ends_with(".wav") || fp.Ends_with(".m3u") || fp.Ends_with(".avi")||fp.Ends_with(".asf")|| fp.Ends_with(".wm")|| fp.Ends_with(".wmp")|| fp.Ends_with(".wmv")|| fp.Ends_with(".ram")|| fp.Ends_with(".rm")|| fp.Ends_with(".rp")|| fp.Ends_with(".rpm")|| fp.Ends_with(".rt")|| fp.Ends_with(".smi")|| fp.Ends_with(".dat")|| fp.Ends_with(".m1v")|| fp.Ends_with(".m2p")|| fp.Ends_with(".m2t")|| fp.Ends_with(".m2ts")|| fp.Ends_with(".m2v")|| fp.Ends_with(".mpv2")|| fp.Ends_with(".mpe")|| fp.Ends_with(".mpeg")|| fp.Ends_with(".mpg")|| fp.Ends_with(".mpv2")|| fp.Ends_with(".pss")|| fp.Ends_with(".pva")|| fp.Ends_with(".tp")|| fp.Ends_with(".tpr")|| fp.Ends_with(".ts")|| fp.Ends_with(".m4p")|| fp.Ends_with(".m4b")|| fp.Ends_with(".m4v")|| fp.Ends_with(".mpeg4")|| fp.Ends_with(".3g2")|| fp.Ends_with(".3gp")|| fp.Ends_with(".3gp2")|| fp.Ends_with(".3gpp")|| fp.Ends_with(".mov")|| fp.Ends_with(".qt")|| fp.Ends_with(".f4v")|| fp.Ends_with(".hlv")|| fp.Ends_with(".ifo")|| fp.Ends_with(".vob")|| fp.Ends_with(".ass")|| fp.Ends_with(".srt")|| fp.Ends_with(".ssa")|| fp.Ends_with(".asx")|| fp.Ends_with(".cue")|| fp.Ends_with(".kpl")|| fp.Ends_with(".kpl")|| fp.Ends_with(".pls")|| fp.Ends_with(".qpl")|| fp.Ends_with(".smpl")|| fp.Ends_with(".wv")|| fp.Ends_with(".wma")|| fp.Ends_with(".tta")|| fp.Ends_with(".tak")|| fp.Ends_with(".ra")|| fp.Ends_with(".ogg")|| fp.Ends_with(".mpa")|| fp.Ends_with(".mp2")|| fp.Ends_with(".mka")|| fp.Ends_with(".midi")|| fp.Ends_with(".m4a")|| fp.Ends_with(".m2a")|| fp.Ends_with(".m1a")|| fp.Ends_with(".flac")|| fp.Ends_with(".dts") || fp.Ends_with(".cda")|| fp.Ends_with(".ape")|| fp.Ends_with(".amr")|| fp.Ends_with(".ac")|| fp.Ends_with(".aac")|| fp.Ends_with(".amv")|| fp.Ends_with(".bik")|| fp.Ends_with(".dts")|| fp.Ends_with("csf")|| fp.Ends_with(".divx")|| fp.Ends_with(".evo")|| fp.Ends_with(".ivm")|| fp.Ends_with(".mod")|| fp.Ends_with(".mts")|| fp.Ends_with(".ogm")|| fp.Ends_with(".pmp")|| fp.Ends_with(".scm")|| fp.Ends_with(".tod")|| fp.Ends_with(".vp6")|| fp.Ends_with(".webm")|| fp.Ends_with(".xlmv")  || fp.Ends_with(".jar"));

        }

        private bool isprogram(string fp)
        {
            return (fp.EndsWith(".exe") || fp.EndsWith(".com") || fp.EndsWith(".msi") || fp.EndsWith(".bin") || fp.EndsWith(".msc") || fp.EndsWith(".cpl") || fp.EndsWith(".msp") || fp.EndsWith(".hta") || fp.EndsWith(".scr") || fp.EndsWith(".jar"));
            //MSP  
        }

     
        private bool IsText(string fp)
        {
            return fp.EndsWith(".txt");

        }

        private bool IsShortCut(string fp)
        {
            return fp.EndsWith(".lnk");
        }

        private void GpxOptions_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxsaveExt.Checked) chxNEWEXTEN.Checked = false; ;
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            int suc = 0;
            int faile = 0;
            string notice = "";
            if (ExistedFolder() == false)
                return;
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;

            string[] files = Directory.GetFiles(txbxPath.Text, "*.*");
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    File.Delete(files[i]);
                    suc++;
                }
                catch {
                    faile++;
                    MessageBox.Show("Can not delete file in use"+Environment.NewLine+" plz Free it first ;)","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
            }
            MessageBox.Show("Failed = " + faile.ToString() + Environment.NewLine + "Succeeded=" + suc.ToString(), "Result");

            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panlRenameALL.Enabled = rb_RenameAll.Checked;
        }

        private void RBDeleteWhich_CheckedChanged(object sender, EventArgs e)
        {
            panelDeleteWhich.Enabled = btnDeleteWhich.Enabled=RBDeleteWhich.Checked;
        }

        private void RbDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            btnDA.Enabled = RbDeleteAll.Checked;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txbxSizeless.Enabled = RBsizeLessThan.Checked;
        }

        private void txbxSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long i = long.Parse(txbxSizeless.Text);
            }
            catch { txbxSizeless.Text = ""; }
        }

        private void btnDeleteWhich_Click(object sender, EventArgs e)
        {

           int  Failed = 0;
           int succed = 0;
            if (ExistedFolder() == false)
                return;


            long lessthan = 1000;
            long bigzan = 1000000;

            if (txbxSizeGreater.Text.Length > 0)
                bigzan = GetLongNum(txbxSizeGreater.Text);

            if (txbxSizeless.Text.Length > 0)
                lessthan = GetLongNum(txbxSizeless.Text);

            string[] files = Directory.GetFiles(txbxPath.Text, "*.*");
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    bool done = false;

                    string f = files[i];
                    if (RBsizeLessThan.Checked)
                        done = DeleteWhichLessThan(f, lessthan);
                    else if (rbSizeGreater.Checked)
                        done = DeleteWhichGreaterThan(f, bigzan);
                    else if (rbZeroSize.Checked)
                        done = DeleteZeroSize(f);
                    else if (RBCertainEx.Checked)
                        done = DeleteWithThisExten(f, txbxSimilarExten.Text.Trim());
                    else if (RBContaintText.Checked)
                        done = DeleteThatContainText(f, rtxbxContainText.Text);
                    else if (RBPorn.Checked)
                        done = DeletesuspiciouspornFile(f);
                    else if (rbCerainName.Checked)
                        done = DeletethatHasThisname(f, txbxNameLike.Text);
                    else if (RBwEB.Checked)
                        done = DeleteWebPages(f);
                    else if (rbTextFiles.Checked)
                        done = DeleteTextFile(f);

                    if (done)
                        succed++;

                }
                catch { Failed++; }
            }

                MessageBox.Show("Failed = " + Failed.ToString()+Environment.NewLine+"Succeeded="+succed.ToString(),"Result");
        }

        private bool DeleteTextFile(string f)
        {
            try
            {
                if (f.Ends_with(".txt"))
                {
                    File.Delete(f);
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        private bool DeleteWebPages(string f)
        {
            List<string> webwords = new List<string> { ".html",".htm",".shtml", ".xhtml",".jsp",".less",".scss", ".php", ".php4", ".asp", "aspx" ,".js",".php3",".phtml",".css3",".css",".xml"};
            if (f.Ends_with(webwords))
            {
                File.Delete(f);
                return true;
            }
            return false;
        }

        private bool DeletethatHasThisname(string f, string p)
        {
            string[] sepdBySlash = f.Split(new char[] { '\\' });
            string fileName = sepdBySlash[sepdBySlash.Length - 1].ToLower();
            if(fileName.Contains(p.ToLower()))
            { 
                File.Delete(f);
                return true;
            }
            return false;
        }

        private bool DeletesuspiciouspornFile(string f)
        {
            try
            {
                string[] sepdBySlash = f.Split(new char[] { '\\' });
                string fileName = sepdBySlash[sepdBySlash.Length - 1].ToLower();
                List<string> pornWords = new List<string> { "porn", "hot", "sex", "milf", "teen", "amateur", "xxx", "xnxx", "brazzers", "bitch", "tube", "horny", "cock", "ass", "pussy", "cum", "fuck", "horny", "lesbian", "anal", "tits", "blowjob", "blonde", "blondage", "Brunette", "chabby", "casting", "amateur", "american", "anal sex ", "anime", "arab / arabian", "asian woman", "ass", "ass gaping", "ass to mouth", "ass fucked", "babysitter", "bbw", "bdsm", "beach sex ", "big ass", "big cock", "big girl", "big tits", "black girls", "black hair", "blonde", "blowjob", "bondage", "brazilian", "brunette", "butt", "cam videos", "casting", "chubby", "classic view", "classic porn", "clips (small)", "college", "compilation", "creampie", "cumshot", "deepthroat", "doctor", "ebony", "ex-girlfriend", "exhibitionism", "fat", "female ejaculation", "fisting / fist-fucking", "french / france", "fucked / fucking", "gagging", "galleries", "gangbang", "gape / gaping ", "gay porn ", "german", "girlfriend / gf", "granny", "hairy pussy", "handjob", "hardcore", "heels", "homemade", "huge tits ", "images (xxx) ", "india / indian girls", "interracial", "italian", "jap / japanese", "latina", "lesbian", "maid", "massage", "masturbation", "mature women", "milf", "mom videos", "nurse", "office / work", "oiled", "orgasm (female)", "orgy", "party", "pics / pictures ", "photos", "pornstar", "pov (point of view)", "pregnant", "public", "pussy", "pussy fucking", "pussy squirting", "real amateur", "redhead", "retro", "russian", "school", "schoolgirl", "secretary", "sexy girls", "shaved pussy", "shemale", "small movies", "small tits", "solo girls ", "squirting", "stockings", "sucking", "tags (all)", "teacher", "teen porn", "throat-fucking", "transsexual, ts", "tranny, trans", "university", "vintage porno ", "virgin / virginity", "webcam videos", "wife" };

                foreach (string sw in pornWords)
                    if (fileName.Contains(sw))
                    {
                        File.Delete(f);
                        return true;
                    }
                return false;
            }
            catch { return false; }
           
        }

        private bool DeleteThatContainText(string f, string p)
        {
            if (File.ReadAllText(f).Contains(p))
            {
                File.Delete(f); 
                return true;
            }
            return false;
        }

        private bool DeleteWithThisExten(string p,string cEx="")
        {
            if (p.EndsWith(cEx))
            {
                File.Delete(p);
                return true;
            }
             return false;

        }

        private long GetLongNum(string p)
        {
            try
            {
                return long.Parse(p);
            }
            catch { return 0; }
        }

        private bool DeleteZeroSize(string p)
        {
            if (GetFileSizeOnDisk(p) == 0)
            {
                File.Delete(p);
                return true;
            }
            return false;
        }

        private bool DeleteWhichGreaterThan(string p,long i=1 )
        {
            if (GetFileSizeOnDisk(p) > i)
            {
                File.Delete(p);
                return true;
            }
            return false;
        }

        private bool DeleteWhichLessThan(string p,long i=1)
        {
            if (GetFileSizeOnDisk(p) < i)
            {
                File.Delete(p);
                return true;
            }
            return false;
        }
        public static long GetFileSizeOnDisk(string file)
        {
            try
            {
                var x = new System.IO.FileInfo(file);
                return x.Length / 1000000;
            }
            catch { return -1; }
        }

        [DllImport("kernel32.dll")]
        static extern uint GetCompressedFileSizeW([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
           [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true, PreserveSig = true)]
        static extern int GetDiskFreeSpaceW([In, MarshalAs(UnmanagedType.LPWStr)] string lpRootPathName,
           out uint lpSectorsPerCluster, out uint lpBytesPerSector, out uint lpNumberOfFreeClusters,
           out uint lpTotalNumberOfClusters);

        private void txbxSizeGreater_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long i = long.Parse(txbxSizeGreater.Text);
            }
            catch { txbxSizeGreater.Text = ""; }
        }

        private void rbSizeGreater_CheckedChanged(object sender, EventArgs e)
        {
          txbxSizeGreater.Enabled=  rbSizeGreater.Checked;
        }

        private void chxNEWEXTEN_CheckedChanged(object sender, EventArgs e)
        {
            newExt = lblNewExVal.Visible=chxNEWEXTEN.Checked; 
            if(newExt)checkBoxsaveExt.Checked = false;
            if(chxNEWEXTEN.Checked)
            {
                if (lblNewExVal.Text != "")
                    return;

                UserINP u = new UserINP();
                u.ShowDialog();
                if (u.DialogResult != DialogResult.OK)
                {
                    chxNEWEXTEN.Checked = newExt = false;
                    return;
                }
                if (u.Text[0] != '.') // if user forget the DOT
                    u.Text = ("." + u.Text);
                cus_exten = lblNewExVal.Text = u.Text;
                
            }
        }

        private void lblDirStatue_TextChanged(object sender, EventArgs e)
        {
            if (lblDirStatue.Text == "Not Existed Directory")
                lblDirStatue.ForeColor = Color.Red;
            else
                lblDirStatue.ForeColor = Color.Green;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;


        }

        private void RBCertainEx_CheckedChanged(object sender, EventArgs e)
        {
            txbxSimilarExten.Enabled = RBCertainEx.Checked;
        }

        private void txbxSimilarExten_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNewExVal_Click(object sender, EventArgs e)
        {
            UserINP u = new UserINP();
            u.ShowDialog();
            if (u.DialogResult != DialogResult.OK)
            {
                chxNEWEXTEN.Checked = newExt = false;
                return;
            }
            if (u.Text[0] != '.') // if user forget the DOT
                u.Text = ("." + u.Text);
            cus_exten = lblNewExVal.Text = u.Text;
        }

        private void linkLabel_About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com/yassergersy");
        }

        private void RBContaintText_CheckedChanged(object sender, EventArgs e)
        {
            rtxbxContainText.Enabled = RBContaintText.Checked; 
        }

        private void btnDeleteShortcutz_Click(object sender, EventArgs e)
        { 
            int sux = 0;
            if (ExistedFolder() == false)
                return;

            string[] files = Directory.GetFiles(txbxPath.Text, "*.*");
            for (int i = 0; i < files.Length; i++)
            {
                if (IsShortCut(files[i]))
                {
                    File.Delete(files[i]);
                    sux++;
                }
            }

            MessageBox.Show("Cleaned="+sux.ToString(),"Result");

        }


        private void timermain_Tick(object sender, EventArgs e)
        {}
        public void som(){
            if (txbxPath.Text.Length < 1)
                return;
            timerticks++;
            if(timerticks==2)
            CheckDirectory();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            btnDeleteShortcutz.Enabled = rbShortCuts.Checked;
        }

        private void rbCerainName_CheckedChanged(object sender, EventArgs e)
        {
            txbxNameLike.Enabled = rbCerainName.Checked;
        }

        private void lnklblLoadExt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExLoader x = new ExLoader();
            if (x.ShowDialog() == DialogResult.OK)
                txbxSimilarExten.Text = x.Text;
            }

        private void txbxSimilarExten_EnabledChanged(object sender, EventArgs e)
        {
            lnklblLoadExt.Enabled = txbxSimilarExten.Enabled;
        }
    }
}
