using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace App15
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class BasicPage1 : App15.Common.LayoutAwarePage
    {
        public BasicPage1()
        {
            this.InitializeComponent();
            
        }
       

        Attendance att = new Attendance();
        FlipView FlipView1 = new FlipView();
        ListBox lb2 = new ListBox();
        TextBlock[] tbs = new TextBlock[100];

       


        public class marks
        {
            public int no;
            public string file;
            public string sno, classnbr, subcode, subject, theory, teacher, cat1, cat2, quiz1, quiz2, quiz3;
            public string[] mymarks = new string[1000];
            public string presentcat1, presentcat2, presentquiz1, presentquiz2, presentquiz3, assign, presentassign;
        }
        
        marks[] mark123 = new marks[20];
        marks m = new marks();

        void func3()
        {

            int m1 = 0;

            StringBuilder arr = new StringBuilder();
            int q = 0;
            string f = m.file;
            string td = "<td>";
            string tdf = "</td>";
            string p = "";
            string[] c;
            int l = 0;
            int g = 0;
            int z = -1;
            mark123[l] = new marks();
            for (int i = 0; i < f.Length - td.Length; i++)
            {

                if (f.Substring(i, td.Length).Equals(td))
                {
                    z++;
                    string count = "";
                    int j = i + td.Length;
                    while (!f.Substring(j, tdf.Length).Equals(tdf))
                    {
                        count = count + f.Substring(j, 1);
                        j++;

                    }
                    g++;

                    mark123[l].mymarks[z] = count;

                    if (count.Equals("Embedded Lab") || count.Equals("Lab Only"))
                    {
                        g = g + 10;
                    }
                    if (g % 18 == 0)
                    {
                        l++;
                        mark123[l] = new marks();
                        z = -1;
                    }
                }
            }

            for (int i = 0; i < l; i++)
                for (int j = 0; j < 18; j++)
                    try
                    {
                        string k = mark123[i].mymarks[j];
                        if (k.Equals("")) ;

                    }
                    catch (Exception e)
                    {
                        mark123[i].mymarks[j] = "";
                    }

            for (int i = 0; i < l; i++)
            {
                mark123[i].sno = mark123[i].mymarks[0];
                mark123[i].classnbr = mark123[i].mymarks[1];
                mark123[i].subcode = mark123[i].mymarks[2];
                mark123[i].subject = mark123[i].mymarks[3];
                mark123[i].theory = mark123[i].mymarks[4];
                mark123[i].teacher = mark123[i].mymarks[5];
                mark123[i].presentcat1 = mark123[i].mymarks[6];
                mark123[i].cat1 = mark123[i].mymarks[7];
                mark123[i].presentcat2 = mark123[i].mymarks[8];
                mark123[i].cat2 = mark123[i].mymarks[9];
                mark123[i].presentquiz1 = mark123[i].mymarks[10];
                mark123[i].quiz1 = mark123[i].mymarks[11];
                mark123[i].presentquiz2 = mark123[i].mymarks[12];
                mark123[i].quiz2 = mark123[i].mymarks[13];
                mark123[i].presentquiz3 = mark123[i].mymarks[14];
                mark123[i].quiz3 = mark123[i].mymarks[15];
                mark123[i].presentassign = mark123[i].mymarks[16];
                mark123[i].assign = mark123[i].mymarks[17];

            }

            m.no = l;

        }

        void display2()
        {
            ListBoxItem[] sta = new ListBoxItem[20];
            // ListBox lb3 = new ListBox();
            //TextBlock tb = new TextBlock();
            // StackPanel ss = new StackPanel();
            //tb.Text += "Sno\tSubcode\t\tSubject\t\tCat1\tCat2";

            // ss.Children.Add(tb);
            //lb3.Items.Add(ss);
            //  lb3.SelectedIndex = 0;
            for (int i = 0; i < m.no; i++)
            {
                sta[i] = new ListBoxItem();
                TextBlock tb1 = new TextBlock();
                //sta[i].Orientation = Orientation.Horizontal;
                tb1.Text += mark123[i].sno + "\t";
                tb1.Text += mark123[i].classnbr + "\t";
                tb1.Text += mark123[i].subcode + "\t";
                tb1.Text += mark123[i].subject + "\t";
                tb1.Text += mark123[i].theory + "\t";
                tb1.Text += mark123[i].teacher + "\t";
                tb1.Text += mark123[i].cat1 + "\t";
                tb1.Text += mark123[i].cat2 + "\t";
                tb1.Text += mark123[i].quiz1 + "\t";
                tb1.Text += mark123[i].quiz2 + "\t";
                tb1.Text += mark123[i].quiz3 + "\t";
                //tb1.Text += mark123[i].presentcat1 + "\t";
                //tb1.Text += mark123[i].presentcat2 + "\t";
                //tb1.Text += mark123[i].presentquiz1 + "\t";
                //tb1.Text += mark123[i].presentquiz2 + "\t";
                //tb1.Text += mark123[i].presentquiz3 + "\t" + "\n";
                sta[i].Content = tb1.Text;

            }
            //  lb2.Items.Add(lb3);
            for (int i = 0; i < m.no; i++)
                lb2.Items.Add(sta[i]);

        }





        public class Attendance
        {

            public string file,attndetails;
            public string post, from_date;
            public string Sno, coursecode, title, type, slot, regdate, attended, total, attendance, debar;
            public int iattend, itotal, iattendance;
        }
        public class Attndetails
        {
            public string sno, date, classslot, status, units, reason;
        }
        Attendance[] a = new Attendance[20];
        int t = -1;

        void myfunc()
        {

            StringBuilder arr = new StringBuilder();
            int m = 0;
            string td = "</td>";
            string f = att.file;
            string temp = "<td align=\"center\">";

            for (int i = 0; i < (f.Length - temp.Length); i++)
            {
                string sub = f.Substring(i, temp.Length);
                if (sub.Equals(temp))
                {
                    m++;
                    string count = "";
                    int j = i + temp.Length;
                    while (!f.Substring(j, td.Length).Equals(td))
                    {
                        count = count + f.Substring(j, 1);
                        j++;
                    }
                    arr.Append(count);
                    arr.Append("\n");

                }


            }

            string temp2 = "<form action=\"attn_report_details.asp\" method=\"POST\">";
            string frm = "</td>";
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < f.Length - temp2.Length; i++)
            {
                string sub2 = f.Substring(i, temp2.Length);
                if (sub2.Equals(temp2))
                {
                    string count2 = "";
                    int j = i;
                    while (!f.Substring(j, frm.Length).Equals(frm))
                    {
                        count2 = count2 + f.Substring(j, 1);
                        j++;
                    }
                    b.Append(count2);
                    b.Append("\n");
                }
            }

            for (int i = 0; i < 20; i++)
            {
                a[i] = new Attendance();
            }

            string p = arr.ToString();

            string[] c = p.Split('\n');
            for (int i = 0; i < c.Length - 5; i++)
            {
                if (i % 6 == 0)
                {
                    t++;
                }
                try
                {
                    a[t].Sno = c[i];
                    a[t].coursecode = c[i + 1];
                    a[t].from_date = c[i + 2];
                    a[t].attended = c[i + 3];
                    a[t].total = c[i + 4];
                    a[t].attendance = c[i + 5];
                    i = i + 5;

                }
                catch (Exception)
                {
                    //tb1.Text = "error";
                }
            }
            t++;
            string p2 = b.ToString();
            string[] c2 = p2.Split('\n');
            for (int i = 0; i < c2.Length; i++)
            {
                a[i].post = c2[i];
            }
            for (int i = 0; i < t; i++)
            {
                try
                {
                    a[i].iattend = int.Parse(a[i].attended);
                    a[i].itotal = int.Parse(a[i].total);
                    a[i].iattendance = int.Parse(a[i].attendance.Substring(0, (a[i].attendance.Length - 1)));
                    if (a[i].iattendance < 75)
                        a[i].debar = "***Debarred***";
                    else a[i].debar = "";

                }
                catch (Exception e)
                {

                    //tb1.Text = "Exception occured"; 
                }
                finally
                {
                    a[i].post = myfunc2(a[i].post);
                }
            }
            string k = "</form><script>document.getElementsByTagName(\"form\")[0].submit();</script>";
            for (int i = 0; i < t; i++)
            {
                a[i].post = a[i].post.Replace("</form>", "");
                a[i].post += k;
            }
        }

        string myfunc2(string fi)
        {

            string ScriptTagString = "<form action=\"";
            int IndexOfScriptTag = fi.IndexOf(ScriptTagString);
            int LengthOfScriptTag = ScriptTagString.Length;
            string InsertionScriptString = "https://academics.vit.ac.in/parent/";
            fi = fi.Insert(IndexOfScriptTag + LengthOfScriptTag, InsertionScriptString);
            return fi;


        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            ring.Height = 50;
            ring.Width = 50;
            ring.IsActive = true;
            Uri ur = new Uri("https://academics.vit.ac.in/parent/attn_report.asp?sem=WS");
            webv.Navigate(ur);            
            //string k="<script>document.getElementsByTagName(\"form\")[0].submit();</script>";
            ////string k2="";
            //for (int i = 0; i < t; i++)
            //{               
            //    a[i].post += k;
            //  //  k2 += a[i].post+"\n";
            //}

            /*WebView webv3 = new WebView();
            gr1.Children.Add(webv3);
            webv3.NavigateToString(a[0].post);
           */
            //FlipView1.Visibility = Visibility.Collapsed;
            //b1.Visibility = Visibility.Collapsed;

           
        }

        Rectangle r2 = new Rectangle();
        Rectangle r = new Rectangle();
        int itmno=0;
        void display()
        {
            // TextBlock[] tbs = new TextBlock[100];
            // StackPanel[] stacks = new StackPanel[30];
            //Slider[] slides = new Slider[30];
            Button[] b1 = new Button[30];
            Button[] b2 = new Button[30];
            ListBox lb = new ListBox();
            ListBoxItem[] stacks = new ListBoxItem[100];
            //  ListBoxItem l2 = new ListBoxItem();

            TextBlock tbv = new TextBlock();
            StackPanel stack = new StackPanel();
            /* l2.Content = "\tS No\tCourseCode    Attended\t Total\tPercentage";
             l2.FontFamily = new FontFamily("Franklin Gothic Heavy");
             l2.FontSize = 36;
             l2.CharacterSpacing = 10;
            
             l2.Height = 60;*/
            // stack = new StackPanel();
            // stack.Children.Add(tbv);
            // l2.Items.Add(stack);
            //  l2.SelectedIndex = 0;
            //l2.Height = 200;

            // lb.Items.Add(l2);

            /*  StackPanel aaa = new StackPanel();
              aaa.Children.Add(l2);
              aaa.Children.Add(lb);
            */
            for (int i = 0; i < t; i++)
            {

                TextBlock temp = new TextBlock();

                //slides[i] = new Slider();
                b1[i] = new Button();
                b2[i] = new Button();
                stacks[i] = new ListBoxItem();
                tbs[i] = new TextBlock();
                b1[i].Content = "+";
                b1[i].Height = 50;
                b1[i].Width = 50;
                b1[i].Foreground = new SolidColorBrush(Colors.OrangeRed);
                b1[i].Background = new SolidColorBrush(Colors.PaleGreen);

                b2[i].Content = "-";
                b2[i].Height = 50;
                b2[i].Width = 50;
                b2[i].Foreground = new SolidColorBrush(Colors.OrangeRed);
                b2[i].Background = new SolidColorBrush(Colors.PaleGreen);

                //slides[i].Width = 340;
                //slides[i].Maximum = double.Parse(a[i].total);
                //slides[i].Value = double.Parse(a[i].attended);
                //stacks[i].Orientation = Orientation.Horizontal;
                stacks[i].Margin = new Thickness(0, 10, 0, 10);
                //slides[i].Margin = new Thickness(50, -15, 0, -25);
                b1[i].Margin = new Thickness(50, -20, 0, -20);
                b2[i].Margin = new Thickness(50, -20, 0, -20);

                tbs[i].Text = "\t" + a[i].Sno + "\t\t\t" + a[i].coursecode + "\t\t\t\t" + a[i].attended + "\t\t\t" + a[i].total + "\t\t\t" + a[i].attendance;
                temp.Text = "\t" + a[i].debar;
                stacks[i].Content = tbs[i].Text;
                //  stacks[i].Content += b1[i];
                //stacks[i].Children.Add(tbs[i]);
                //stacks[i].Children.Add(slides[i]);
                // stacks[i].Children.Add(b1[i]);
                //stacks[i].Children.Add(b2[i]);

                try
                {
                    stacks[i].Content += "\t" + temp.Text;
                    // stacks[i].Children.Add(temp);

                }
                catch (Exception)
                { }


            }
            

            for (int i = 0; i < t; i++)
            {
                lb.Items.Add(stacks[i]);
                if (a[i].debar.Equals("***Debarred***"))
                {

                    stacks[i].Background = new SolidColorBrush(Colors.Red);
                }

            }
            StackPanel ss = new StackPanel();


            r.Width = 30;
            r.Height = 30;
            r.Fill = new SolidColorBrush(Colors.GreenYellow);
            r2.Width = 30;
            r2.Height = 30;
            r2.Fill = new SolidColorBrush(Colors.GreenYellow);

            FlipView1.Height = 630;

            try
            {

                FlipView1.Items.Add(lb);
                FlipView1.Items.Add(lb2);
                stackPanel1.Children.Add(FlipView1);
                ss.Children.Add(r2);
                ss.Children.Add(r);
                stackPanel1.Children.Add(ss);
            }

            catch (Exception)
            { }
            gr1.Background = new SolidColorBrush(Colors.White);
            ss.Orientation = Orientation.Horizontal;
            ss.HorizontalAlignment = HorizontalAlignment.Center;
            r.Margin = new Thickness(10);
            r2.Margin = new Thickness(10);
            r.Tapped += r_Tapped;
            r2.Tapped += r2_Tapped;
            r2.PointerEntered += r2_PointerEntered;
            r2.PointerExited += r2_PointerExited;
            r.PointerEntered += r_PointerEntered;
            r.PointerExited += r_PointerExited;
            FlipView1.SelectionChanged += FlipView1_SelectionChanged;
            r2.Width = 40;
            r2.Height = 40;
            //  lb.SelectionChanged += lb_SelectionChanged;
            for (int i = 0; i < t; i++)
            {
                b1[i].Name = i.ToString();
                b2[i].Name = i.ToString();
                b1[i].Click += MainPage_Click;
                b2[i].Click += MainPage_Click2;
            }
            lb.Background = new SolidColorBrush(Colors.Wheat);
            lb.DoubleTapped += lb_DoubleTapped;
        }

        void lb_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ListBox LB = (ListBox)sender;
            itmno=LB.SelectedIndex;
            WebView webv3 = new WebView();
            gr1.Children.Add(webv3);
            webv3.NavigateToString(a[itmno].post);
            webv3.Visibility = Visibility.Collapsed;
            webv3.LoadCompleted += webv3_LoadCompleted;
            
        }

        void MainPage_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            int i = int.Parse(b.Name);

            a[i].iattend += 1;
            a[i].itotal += 1;
            a[i].iattendance = 100 * a[i].iattend / a[i].itotal;
            tbs[i].Text = "\t" + a[i].Sno + "\t\t\t" + a[i].coursecode + "\t\t\t\t" + a[i].iattend.ToString() + "\t\t\t" + a[i].itotal.ToString() + "\t\t\t" + a[i].iattendance.ToString() + "%";
        }

        void MainPage_Click2(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;
            int i = int.Parse(b.Name);
            a[i].iattend -= 1;
            a[i].itotal -= 1;
            a[i].iattendance = 100 * a[i].iattend / a[i].itotal;
            tbs[i].Text = "\t" + a[i].Sno + "\t\t\t" + a[i].coursecode + "\t\t\t\t" + a[i].iattend.ToString() + "\t\t\t" + a[i].itotal.ToString() + "\t\t\t" + a[i].iattendance.ToString() + "%";

        }

        void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lll = (ListBox)sender;
            Grid ss = new Grid();

            if (lll.SelectedIndex == 1)
            {
                Button tt = new Button();
                tt.Height = 30;
                tt.Width = 30;
                tt.HorizontalAlignment = HorizontalAlignment.Center;

                tt.Content = "+";
                ss.Children.Add(tt);

                lll.Items.Insert(2, ss);

            }
        }

        void abc()
        {
            FlipView1.SelectedIndex = 1;

        }

        void FlipView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FlipView1.SelectedIndex == 1)
            {
                out1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                out2.Visibility = Windows.UI.Xaml.Visibility.Visible;

                r.Height = 40;
                r.Width = 40;
                r2.Height = 30;
                r2.Width = 30;
            }
            else
            {
                out1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                out2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                r.Height = 30;
                r.Width = 30;
                r2.Height = 40;
                r2.Width = 40;
            }

        }

        void r_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            r.Fill = new SolidColorBrush(Colors.GreenYellow);

        }

        void r_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            r.Fill = new SolidColorBrush(Colors.OrangeRed);

        }

        void r2_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            r2.Fill = new SolidColorBrush(Colors.GreenYellow);
        }

        void r2_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            r2.Fill = new SolidColorBrush(Colors.OrangeRed);

        }


        void r2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlipView1.SelectedIndex = 0;
            r2.Width = 40;
            r2.Height = 40;
            r.Width = 32;
            r.Height = 32;
        }

        void r_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlipView1.SelectedIndex = 1;
            r.Width = 40;
            r.Height = 40;
            r2.Width = 32;
            r2.Height = 32;

        }

       
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>


        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            


        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        }








        private void marks_Click(object sender, RoutedEventArgs e)
        {
            /* try
             {
                 await AccessTheWebAsync();
             }
             catch (Exception)
             {
                 // tb1.Text = "No internet connection";
             }*/
            ring.IsActive = true;
            Uri ur = new Uri("https://academics.vit.ac.in/parent/marks.asp?sem=WS");
            webv.Navigate(ur);

        }


        //itemList now contain all the span tags content having its class as hidden first
        private void webv_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string html = "";

                try
                {
                    html = webv.InvokeScript("eval", new string[] { "document.documentElement.outerHTML;" });
                }
                catch (Exception)
                { }
            att.file = html;
           
            Uri ur2 = new Uri("https://academics.vit.ac.in/parent/marks.asp?sem=WS");
            webv2.Navigate(ur2);
          
            
        }

        private void webv2_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string html = "";

            ring.IsActive = false;
           
                try
                {
                    html = webv2.InvokeScript("eval", new string[] { "document.documentElement.outerHTML;" });
                }
                catch (Exception)
                { }

           
            m.file = html;
            out1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            myfunc();
            func3();

            display2();
            display();
            
        }

        void webv3_LoadCompleted(object sender, NavigationEventArgs e)
        {
            WebView webv3 = (WebView)sender;
            
            att.attndetails = webv3.InvokeScript("eval", new string[] { "document.documentElement.outerHTML;" });
            dispattn();
        }


        async void dispattn()
        {
            string k = att.attndetails;
            string count = "";
            int flag = 0;
            StringBuilder arr = new StringBuilder();

            string temp = "<tr bgcolor=\"#e6f2ff\">";
            string temp2 = "<tr bgcolor=\"#fff9ea\">";
            for (int i = 0; i < k.Length - temp.Length; i++)
            {
                if (k.Substring(i, temp.Length).Equals(temp) || k.Substring(i, temp2.Length).Equals(temp2))
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        continue;
                    }

                    int j = i + temp.Length;
                    while (!k.Substring(j, "</tr>".Length).Equals("</tr>"))
                    {
                        count += k.Substring(j, 1);
                        j++;
                    }
                    i = j;
                }

            }

            int m;
            string count2 = "";
            for (int i = 0; i < count.Length - 2; i++)
            {
                if (count.Substring(i, 1).Equals(">"))
                {
                    if (!count.Substring(i, 2).Equals("><"))
                    {
                        m = i + 1;
                        while (!count.Substring(m, 1).Equals("<"))
                        {
                            count2 += count.Substring(m, 1);
                            m++;
                        }
                        i = m;
                        count2 += "\n";
                    }
                }

            }
            string[] s = count2.Split('\n');
            Attndetails[] attn = new Attndetails[100];
            int l1 = 0;
            try
            {
                for (int i = 0; i < s.Length - 1; i = i + 6)
                {
                    attn[l1] = new Attndetails();
                    attn[l1].sno = s[i];
                    attn[l1].date = s[i + 1];
                    attn[l1].classslot = s[i + 2];
                    attn[l1].status = s[i + 3];
                    attn[l1].units = s[i + 4];
                    attn[l1].reason = s[i + 5];
                    l1++;
                }
            }
            catch (Exception e1)
            {
            }
            string disp = "Sno\tDate\t\tClass Slot\tStatus\t\tClass Units\tReason\n\n";
            for (int i = 0; i < l1; i++)
            {
                disp += attn[i].sno + "\t" + attn[i].date + "\t" + attn[i].classslot + "\t\t" + attn[i].status + "\t\t" + attn[i].units + "\t\t" + attn[i].reason + "\n";
            }

            try
            {
                MessageDialog dlg = new MessageDialog(disp, a[itmno].coursecode + " Attendance Details");
                await dlg.ShowAsync();
            }
            catch (Exception e12)
            { 
            }
        }

       

     

     
    }
}
