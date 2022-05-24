using System;
using System.Collections;
using System.IO;
using System.Text;
namespace imageprocess
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void fileOpenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse PRN Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "prn files (*.prn)|*.prn",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;           // Taking the HEX or PRN file

                }
                CheckForIllegalCrossThreadCalls = false;
                Thread th1 = new Thread(() => hexReadFile(textBox1.Text));
                th1.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
           
        }
        
        private void hexReadFile(String filename)
        {
            try
            {
                byte[] byt = new byte[300];
                BinaryReader br = new BinaryReader(File.OpenRead(filename));

                StringBuilder imgaray = new StringBuilder(); // for BLACK   (K) color
                Double i = 0;
                while(br.PeekChar() >=0 )
                {
                    Thread.Sleep(1);

                    imgaray.Append(br.ReadByte());
                    
                }

                uint byte_per_line = (uint)(imgaray[17] << 8);


                byte_per_line = (uint)(byte_per_line | imgaray[16]);


                textBox2.Text = byte_per_line.ToString();

                 uint image_height = (uint)((imgaray[21] << 8) | imgaray[20] );


                textBox3.Text = image_height.ToString();

                 uint image_width = (uint)((imgaray[25] << 8) | imgaray[24]);


                textBox4.Text = image_width.ToString();
                Storing_Img_Data(byte_per_line, image_height);
                br.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            
        }

        private void Storing_Img_Data(uint byte_per_line, uint image_height)
        {
            //KCMY
            StringBuilder Color_K = new StringBuilder(); // for BLACK   (K) color
            StringBuilder Color_C = new StringBuilder(); // for CYAN    (C) color
            StringBuilder Color_M = new StringBuilder(); // for MAGENTA (M) color
            StringBuilder Color_Y = new StringBuilder(); // for YELLOW  (Y) color
            


            
            
            
            
             
            Double Start_Add = 336;
            Double End_Add = 336 + byte_per_line - 1;
            for (int x = 0; x < image_height; x++){
                for(int i = 1; i <= 4; i++)
                {
                    Start_Add +=  (x * byte_per_line);
                    End_Add +=   ((x + 1) * byte_per_line) - 1;

                    for (Double y = Start_Add; y <= End_Add; y++)
                    {
                        switch (i)
                        {
                            case 1:
                                Color_K.Append(imgaray[y]);

                                break;
                        }
                    }
                }

            }
        }
        private void hexReadFile1(String filename)
        {
            try
            {
                byte[] byt = new byte[300];
                BinaryReader br = new BinaryReader(File.OpenRead(filename));

                /*     for (int i = 0x10; i <= 0x11; i++)
                     {
                         br.BaseStream.Position = i;
                         textBox1.Text = br.ReadByte().ToString("x2");
                     }*/
                for (int i = 151; i < 300; i++)
                {
                    Thread.Sleep(1);
                    //byt[i] = br.ReadByte().ToString("x2");
                    textBox3.AppendText(br.ReadByte().ToString("x2"));
                    i++;

                }
                br.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }

        }

        private void hexReadFile2(String filename)
        {
            try
            {
                byte[] byt = new byte[300];
                BinaryReader br = new BinaryReader(File.OpenRead(filename));

                /*     for (int i = 0x10; i <= 0x11; i++)
                     {
                         br.BaseStream.Position = i;
                         textBox1.Text = br.ReadByte().ToString("x2");
                     }*/
                for (int i = 301; i < 450; i++)
                {
                    Thread.Sleep(1);

                    //byt[i] = br.ReadByte().ToString("x2");
                    textBox4.AppendText(br.ReadByte().ToString("x2"));
                    i++;

                }
                br.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}