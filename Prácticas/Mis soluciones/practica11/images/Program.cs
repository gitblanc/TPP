using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;


namespace TPP.Laboratory.Concurrency.Lab11 {

    class Program {

        static void Main() {
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            string[] files = Directory.GetFiles(@"..\..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\..\pics\rotated";
            Directory.CreateDirectory(newDirectory);
            foreach (string file in files) {
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file)) {
                    Console.WriteLine("Processing the file \"{0}\".", fileName);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
            }
            chrono.Stop();
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", chrono.ElapsedMilliseconds);
        }
    }

}
