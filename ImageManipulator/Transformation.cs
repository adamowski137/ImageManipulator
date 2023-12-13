using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace ImageManipulator
{
    public static class Transformation
    {
        public static Func<Bitmap, TransformationArgs, Bitmap> None { get; } = new Func<Bitmap, TransformationArgs, Bitmap>((Bitmap i, TransformationArgs args) => { return i; });

        public static Func<Bitmap, TransformationArgs, Bitmap> Negate { get; } = new Func<Bitmap, TransformationArgs, Bitmap>((Bitmap image, TransformationArgs args) =>
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap newImage = new Bitmap(width, height);

            if (args.Mode == Mode.WholeArea)
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;
                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {

                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = (byte)(255 - imagePtr[index + 2]);
                            byte G = (byte)(255 - imagePtr[index + 1]);
                            byte B = (byte)(255 - imagePtr[index]);

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }
            else
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;
                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = imagePtr[index + 2];
                            byte G = imagePtr[index + 1];
                            byte B = imagePtr[index];
                            if (args.Modified[i, j])
                            {
                                A = imagePtr[index + 3];
                                R = (byte)(255 - imagePtr[index + 2]);
                                G = (byte)(255 - imagePtr[index + 1]);
                                B = (byte)(255 - imagePtr[index]);
                            }

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }

            return newImage;
        });

        public static Func<Bitmap, TransformationArgs, Bitmap> ChangeBrightness { get; } = new Func<Bitmap, TransformationArgs, Bitmap>((Bitmap image, TransformationArgs args) =>
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            int width = image.Width;
            int height = image.Height;

            if(args.Mode == Mode.WholeArea)
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;

                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        for (int i = 0; i < width; i++)
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = (byte)Math.Max(Math.Min(imagePtr[index + 2] + args.Brightness, 255), 0);
                            byte G = (byte)Math.Max(Math.Min(imagePtr[index + 1] + args.Brightness, 255), 0);
                            byte B = (byte)Math.Max(Math.Min(imagePtr[index] + args.Brightness, 255), 0);

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        }
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }
            else
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;
                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = imagePtr[index + 2];
                            byte G = imagePtr[index + 1];
                            byte B = imagePtr[index];
                            if (args.Modified[i, j])
                            {
                                A = imagePtr[index + 3];
                                R = (byte)Math.Max(Math.Min(imagePtr[index + 2] + args.Brightness, 255), 0);
                                G = (byte)Math.Max(Math.Min(imagePtr[index + 1] + args.Brightness, 255), 0);
                                B = (byte)Math.Max(Math.Min(imagePtr[index] + args.Brightness, 255), 0);
                            }

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }

            return newImage;
        });

        public static Func<Bitmap, TransformationArgs, Bitmap> ChangeGamma { get; } = new Func<Bitmap, TransformationArgs, Bitmap>((Bitmap image, TransformationArgs args) =>
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            int width = image.Width;
            int height = image.Height;
            if(args.Mode == Mode.WholeArea)
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;

                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = (byte)(Math.Pow(imagePtr[index + 2] / 255.0f, args.Gamma) * 255);
                            byte G = (byte)(Math.Pow(imagePtr[index + 1] / 255.0f, args.Gamma) * 255);
                            byte B = (byte)(Math.Pow(imagePtr[index] / 255.0f, args.Gamma) * 255);

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }

            else
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;
                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = imagePtr[index + 2];
                            byte G = imagePtr[index + 1];
                            byte B = imagePtr[index];
                            if (args.Modified[i, j])
                            {
                                A = imagePtr[index + 3];
                                R = (byte)(Math.Pow(imagePtr[index + 2] / 255.0f, args.Gamma) * 255);
                                G = (byte)(Math.Pow(imagePtr[index + 1] / 255.0f, args.Gamma) * 255);
                                B = (byte)(Math.Pow(imagePtr[index] / 255.0f, args.Gamma) * 255);
                            }

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }
            return newImage;
        });

        public static Func<Bitmap, TransformationArgs, Bitmap> Contrast = new Func<Bitmap, TransformationArgs, Bitmap>((Bitmap image, TransformationArgs args) =>
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            int width = image.Width;
            int height = image.Height;

            if(args.Mode == Mode.WholeArea)
            {

                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;

                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];

                            byte getColor(byte v)
                            {
                                if (v < args.Contrast)
                                    return 0;
                                if (v > 255 - args.Contrast)
                                    return 255;
                                byte dx = (byte)(255 - 2 * args.Contrast);
                                byte dy = 255;
                                byte c = (byte)(-dy / dx * args.Contrast);
                                return (byte)(dy / dx * v + c);
                            }

                            byte R = getColor(imagePtr[index + 2]);
                            byte G = getColor(imagePtr[index + 1]);
                            byte B = getColor(imagePtr[index]);

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }
            else
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;
                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = imagePtr[index + 2];
                            byte G = imagePtr[index + 1];
                            byte B = imagePtr[index];
                            if (args.Modified[i, j])
                            {
                                A = imagePtr[index + 3];
                                byte getColor(byte v)
                                {
                                    if (v < args.Contrast)
                                        return 0;
                                    if (v > 255 - args.Contrast)
                                        return 255;
                                    byte dx = (byte)(255 - 2 * args.Contrast);
                                    byte dy = 255;
                                    byte c = (byte)(-dy / dx * args.Contrast);
                                    return (byte)(dy / dx * v + c);
                                }

                                R = getColor(imagePtr[index + 2]);
                                G = getColor(imagePtr[index + 1]);
                                B = getColor(imagePtr[index]);
                            }

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }

            return newImage;
        });

        public static Func<Bitmap, TransformationArgs, Bitmap> Custom { get; } = new Func<Bitmap, TransformationArgs, Bitmap>((Bitmap image, TransformationArgs args) =>
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            int width = image.Width;
            int height = image.Height;

            if(args.Mode == Mode.WholeArea)
            {

                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;

                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = interpolate(imagePtr[index + 2], args.CustomFunctionValues);
                            byte G = interpolate(imagePtr[index + 1], args.CustomFunctionValues);
                            byte B = interpolate(imagePtr[index], args.CustomFunctionValues);

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }
            else
            {
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                int bytesPerPixel = 4; // Assuming 32bpp (8 bits per channel for ARGB)
                int stride = imageData.Stride;
                unsafe
                {
                    byte* imagePtr = (byte*)imageData.Scan0;
                    byte* newImagePtr = (byte*)newImageData.Scan0;

                    Parallel.For(0, height, j =>
                    {
                        Parallel.For(0, width, i =>
                        {
                            int index = j * stride + i * bytesPerPixel;

                            byte A = imagePtr[index + 3];
                            byte R = imagePtr[index + 2];
                            byte G = imagePtr[index + 1];
                            byte B = imagePtr[index];
                            if (args.Modified[i, j])
                            {
                                A = imagePtr[index + 3];
                                R = interpolate(imagePtr[index + 2], args.CustomFunctionValues);
                                G = interpolate(imagePtr[index + 1], args.CustomFunctionValues);
                                B = interpolate(imagePtr[index], args.CustomFunctionValues);
                            }

                            newImagePtr[index] = B;
                            newImagePtr[index + 1] = G;
                            newImagePtr[index + 2] = R;
                            newImagePtr[index + 3] = A;
                        });
                    });
                }

                image.UnlockBits(imageData);
                newImage.UnlockBits(newImageData);
            }

            return newImage;
        });

        private static byte interpolate(byte x, int[] customFunctionValues)
        {
            if (x % 32 == 0)
            {
                return (byte)customFunctionValues[x / 32];
            }

            int lowerIdx = x / 32;
            int upperIdx = (x / 32) + 1;

            int lowerV = customFunctionValues[lowerIdx];
            int upperV = customFunctionValues[upperIdx];

            int lower = 32 * lowerIdx;
            int upper = 32 * upperIdx;

            return (byte)Math.Max(Math.Min(lowerV + (upperV - lowerV) * (x - lower) / (upper - lower), 255), 0);
        }

    }

    public record TransformationArgs(int Brightness = 0, float Gamma = 1, byte Contrast = 0, int[] CustomFunctionValues = null, Mode Mode = Mode.WholeArea, bool[,] Modified = null);
}
