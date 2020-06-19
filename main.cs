using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ImgReader {
     class ReaderMain {

          String path;
          String fileContent;

          public void run() {

              OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = "c://";
                    openFileDialog.Filter = "png file (.png)|*.png|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if(openFileDialog.ShowDialog() == DialogResult.OK) {
                         path = openFileDialog.FileName;

                         Stream fileStream = openFileDialog.OpenFile();

                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                fileContent = reader.ReadToEnd();
                            }
                    }


               //MessageBox.Show(fileContent, "File Content at path: " + path, MessageBoxButtons.OK);

               Console.WriteLine(path);

               Bitmap img = new Bitmap(path);
               Console.WriteLine();

               for(int y = 0; y < img.Height; y++) {
                    for(int x = 0; x < img.Width; x++) {
                         if((img.GetPixel(x, y).GetBrightness() > 1.0 / 5 * 4 && img.GetPixel(x, y).GetBrightness() <= 1.0 / 5 * 5) || img.GetPixel(x, y).A == 0) {
                              Console.Write("  ");
                         } else if(img.GetPixel(x, y).GetBrightness() > 1.0 / 5 * 3 && img.GetPixel(x, y).GetBrightness() < 1.0 / 5 * 4) {
                              Console.Write("░░");
                         } else if(img.GetPixel(x, y).GetBrightness() > 1.0 / 5 * 2 && img.GetPixel(x, y).GetBrightness() < 1.0 / 5 * 3) {
                              Console.Write("▒▒");
                         } else if(img.GetPixel(x, y).GetBrightness() > 1.0 / 5 * 1 && img.GetPixel(x, y).GetBrightness() < 1.0 / 5 * 2) {
                              Console.Write("▓▓");
                         } else if(img.GetPixel(x, y).GetBrightness() >= 1.0 / 5 * 0 && img.GetPixel(x, y).GetBrightness() < 1.0 / 5 * 1) {
                              Console.Write("██");
                         } else {
                              Console.Write("#");
                         }
                    }
                    Console.Write("\n");
               }
          }

          [STAThread]
          public static void Main(string[] args)
          {
               ReaderMain main = new ReaderMain();
               main.run();
               Console.ReadKey();
          }
     }
}
