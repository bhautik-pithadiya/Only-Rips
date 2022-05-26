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

                BinaryReader br = new BinaryReader(File.OpenRead(filename));

                //44237136
                //273936
                byte[] byt = new byte[273936];
                byte[] imgaray = new byte[273936];
                
                
                for(int i=0; i < 273936; i++)
                {
                    //Thread.Sleep(1);

                    imgaray[i] = br.ReadByte();

                }
                //textBox6.Text =imgaray.ToString();
                

                uint byte_per_line = (uint)(imgaray[17] << 8);


                byte_per_line = (uint)(byte_per_line | imgaray[16]);


                textBox2.Text = byte_per_line.ToString();

                 uint image_height = (uint)((imgaray[21] << 8) | imgaray[20] );


                textBox3.Text = image_height.ToString();

                 uint image_width = (uint)((imgaray[25] << 8) | imgaray[24]);


                textBox4.Text = image_width.ToString();
                Storing_Img_Data(byte_per_line,image_width, image_height,imgaray);
                br.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            
        }
        
        private void Storing_Img_Data(uint byte_per_line,uint image_width, uint image_height, byte[] img_array)
        {
            MessageBox.Show("in the function");
            int size = (int)(image_width * image_height);

            String[] Color_K = new String[size];
            String[] Color_C = new String[size]; 
            String[] Color_Y = new String[size]; 
            String[] Color_M = new String[size]; 

            int pixel_k=0, pixel_c = 0 , pixel_y = 0, pixel_m = 0;

            int length = Buffer.ByteLength(img_array);

            int Start_Add = 336;
            int End_Add = 336 + (int)byte_per_line - 1;
            MessageBox.Show("in the loop");
            for(double z = 0; z < image_height; z++)
            {
                for (int j= 0;j < 4; j++){

                    Start_Add += j * (int)byte_per_line;
                    End_Add   += j * (int)byte_per_line - 1;

                    switch (j) {
                        case 0:
                            for(int k = Start_Add; k <= (int)End_Add; k++)
                            {
                                Color_K[pixel_k] = (img_array[k]/255.0).ToString();
                                pixel_k++;
                            }
                            break;
                        case 1:
                            for (int k = Start_Add; k <= (int)End_Add; k++)
                            {
                                Color_C[pixel_c] = (img_array[k] / 255.0).ToString();
                                pixel_c++;
                            }
                            break;
                        case 2:
                            for (int k = Start_Add; k <= (int)End_Add; k++)
                            {
                                Color_M[pixel_m] = (img_array[k] / 255.0).ToString();
                                pixel_m++;
                            }
                            break;
                        case 3:
                            for (int k = Start_Add; k <= (int)End_Add; k++)
                            {
                                Color_Y[pixel_y] = (img_array[k] / 255.0).ToString();
                                pixel_y++;
                            }
                            break;
                    }

                }
            }               // End of for loop of height
            MessageBox.Show("End of Loop");


            
            writefile(Color_C, "D:/Visual Repo/New folder/repos/imageprocess/imageprocess/data/Color_C.txt");
            writefile(Color_Y, "D:/Visual Repo/New folder/repos/imageprocess/imageprocess/data/Color_Y.txt");
            writefile(Color_M, "D:/Visual Repo/New folder/repos/imageprocess/imageprocess/data/Color_M.txt");
            writefile(Color_K, "D:/Visual Repo/New folder/repos/imageprocess/imageprocess/data/Color_K.txt");
            


            int new_size = 3 * size;
            double[] Color_R = new double[size];
            double[] Color_G = new double[size];
            double[] Color_B = new double[size];

            /*
             R = 255 * ( 1 - C ) * ( 1 - k )
             G = 255 * ( 1 - M ) * ( 1 - K )
             B = 255 * ( 1 - Y ) * ( 1 - k )
             */
            textBox5.Text = new_size.ToString();
            int i = 0;
            int index = 0;
            MessageBox.Show("Starting the conversion");
            while(i< size)
            {
                
                float fcolor_c = (float)Convert.ToDouble(Color_C[i]);
                float fcolor_k = (float)Convert.ToDouble(Color_K[i]);
                float fcolor_m = (float)Convert.ToDouble(Color_M[i]);
                float fcolor_y = (float)Convert.ToDouble(Color_Y[i]);
                
                Color_R[i] = 255 * (1.0 - (fcolor_c)) * (1.0 - (fcolor_k));
                Color_G[i] = 255 * (1.0 - (fcolor_m)) * (1.0 - (fcolor_k));
                Color_B[i] = 255 * (1.0 - (fcolor_y)) * (1.0 - (fcolor_k));
                i+=3;
                index++;
                //textBox5.Text = i.ToString();
            }
            MessageBox.Show("R G B created");
            Bitmap img = new Bitmap((int)image_width,(int)image_height );
            img = GetDataPicture((int)image_width, (int)image_height, Color_R, Color_G, Color_B);
            MessageBox.Show("About to create RGB Image");
            
            output_image.Image = img;
            img.Save(@"D:/Visual Repo/New folder/repos/imageprocess/imageprocess/data/final.png");
            
        }

        private void writefile(String[] array, String Filename)
        {
            MessageBox.Show("in the write file function");
            File.WriteAllLines(Filename, array);
            using (StreamReader sr = new StreamReader(Filename))
            {
                string res = sr.ReadToEnd();
            }
            MessageBox.Show("out of  the write file function");
        }

        public Bitmap GetDataPicture(int w, int h, double[] Color_R, double[] Color_G,double[] Color_B)
        {
            MessageBox.Show(h.ToString());
            MessageBox.Show("in Get data Picture");
            Bitmap pic = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            MessageBox.Show("Going in loop");
            int arrayIndex = 0;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                   
                    Color c = Color.FromArgb(
                       (int)Color_R[arrayIndex],
                       (int)Color_G[arrayIndex],
                       (int)Color_B[arrayIndex]
                    );
                    arrayIndex++;
                    //textBox5.Text = arrayIndex.ToString();
                    pic.SetPixel(x, y, c);
                }
                //textBox6.Text = x.ToString();
            }
 
            MessageBox.Show("Coming out of loop");
            return pic;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }








        /*private void hexReadFile1(String filename)
        {
            try
            {
                byte[] byt = new byte[300];
                BinaryReader br = new BinaryReader(File.OpenRead(filename));

                     for (int i = 0x10; i <= 0x11; i++)
                     {
                         br.BaseStream.Position = i;
                         textBox1.Text = br.ReadByte().ToString("x2");
                     }/*
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

        }*/

        /*private void hexReadFile2(String filename)
        {
            try
            {
                byte[] byt = new byte[300];
                BinaryReader br = new BinaryReader(File.OpenRead(filename));

                   for (int i = 0x10; i <= 0x11; i++)
                     {
                         br.BaseStream.Position = i;
                         textBox1.Text = br.ReadByte().ToString("x2");
                     }
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

        }*/
    }
}