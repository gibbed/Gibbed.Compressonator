/* Copyright (c) 2023 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Runtime.InteropServices;

namespace Gibbed
{
    public static partial class Compressonator
    {
        private static bool Is64Bit()
        {
            return Marshal.SizeOf(IntPtr.Zero) == 8;
        }

        private static NativeDelegates Delegates;

        private static readonly int TextureSize;
        private static readonly int CompressOptionsSize;

        static Compressonator()
        {
            TextureSize = Marshal.SizeOf(typeof(TextureNative));
            CompressOptionsSize = Marshal.SizeOf(typeof(CompressOptionsNative));

            if (Is64Bit() == false)
            {
                NativeDelegates delegates;
                delegates.CalculateBufferSize = Native32.CalculateBufferSize;
                delegates.ConvertTexture = Native32.ConvertTexture;
                Delegates = delegates;
            }
            else
            {
                NativeDelegates delegates;
                delegates.CalculateBufferSize = Native64.CalculateBufferSize;
                delegates.ConvertTexture = Native64.ConvertTexture;
                Delegates = delegates;

            }
        }

        private static TextureNative Convert(Texture input)
        {
            TextureNative output;
            output.Size = (uint)TextureSize;
            output.Width = input.Width;
            output.Height = input.Height;
            output.Pitch = input.Pitch;
            output.Format = input.Format;
            output.TranscodeFormat = input.TranscodeFormat;
            output.BlockHeight = input.BlockHeight;
            output.BlockWidth = input.BlockWidth;
            output.BlockDepth = input.BlockDepth;
            output.DataSize = 0;
            output.Data = IntPtr.Zero;
            output.MipSet = IntPtr.Zero;
            return output;
        }

        private static void Convert(ref TextureNative input, ref Texture output)
        {
            output.Width = input.Width;
            output.Height = input.Height;
            output.Pitch = input.Pitch;
            output.Format = input.Format;
            output.TranscodeFormat = input.TranscodeFormat;
            output.BlockHeight = input.BlockHeight;
            output.BlockWidth = input.BlockWidth;
            output.BlockDepth = input.BlockDepth;
        }

        private static CompressOptionsNative Convert(CompressOptions input)
        {
            CompressOptionsNative output;
            output.Size = (uint)CompressOptionsSize;
            output.UseChannelWeighting = input.UseChannelWeighting;
            output.WeightingRed = input.WeightingRed;
            output.WeightingGreen = input.WeightingGreen;
            output.WeightingBlue = input.WeightingBlue;
            output.UseAdaptiveWeighting = input.UseAdaptiveWeighting;
            output.DXT1UseAlpha = input.DXT1UseAlpha;
            output.UseGPUDecompress = input.UseGPUDecompress;
            output.UseCGCompress = input.UseCGCompress;
            output.AlphaThreshold = input.AlphaThreshold;
            output.DisableMultiThreading = input.DisableMultiThreading;
            output.Speed = input.Speed;
            output.GPUDecode = input.GPUDecode;
            output.EncodeWith = input.EncodeWith;
            output.NumberOfThreads = input.NumberOfThreads;
            output.Quality = input.Quality;
            output.RestrictColour = input.RestrictColour;
            output.RestrictAlpha = input.RestrictAlpha;
            output.ModeMask = input.ModeMask;
            output.NumberOfCommands = 0;
            output.CommandSet = default;
            output.InputDefog = input.InputDefog;
            output.InputExposure = input.InputExposure;
            output.InputKneeLow = input.InputKneeLow;
            output.InputKneeHigh = input.InputKneeHigh;
            output.InputGamma = input.InputGamma;
            output.Level = input.Level;
            output.PositionBits = input.PositionBits;
            output.TextureCoordinateBits = input.TextureCoordinateBits;
            output.NormalBits = input.NormalBits;
            output.GenericBits = input.GenericBits;
            output.VcacheSize = input.VcacheSize;
            output.VcacheFIFOSize = input.VcacheFIFOSize;
            output.OverdrawACMR = input.OverdrawACMR;
            output.SimplifyLOD = input.SimplifyLOD;
            output.VertexFetch = input.VertexFetch;
            output.SourceFormat = input.SourceFormat;
            output.DestinationFormat = input.DestinationFormat;
            output.FormatSupportGPU = input.FormatSupportGPU;
            output.PrintInfo = default;
            return output;
        }

        public static uint CalculateBufferSize(ref Texture texture)
        {
            var textureNative = Convert(texture);
            var result = Delegates.CalculateBufferSize(
                ref textureNative);
            Convert(ref textureNative, ref texture);
            return result;
        }

        public static Error ConvertTexture(ref Texture sourceTexture, ref Texture destinationTexture)
        {
            return ConvertTexture(ref sourceTexture, ref destinationTexture, Compressonator.CompressOptions.Default());
        }

        public static Error ConvertTexture(ref Texture sourceTexture, ref Texture destinationTexture, CompressOptions compressOptions)
        {
            var sourceTextureNative = Convert(sourceTexture);
            var destinationTextureNative = Convert(destinationTexture);
            var compressOptionsNative = Convert(compressOptions);

            var sourceData = sourceTexture.Data;
            var destinationData = destinationTexture.Data;

            Error error;
            GCHandle sourceDataHandle = default;
            GCHandle destinationDataHandle = default;
            try
            {
                sourceDataHandle = GCHandle.Alloc(sourceData, GCHandleType.Pinned);
                sourceTextureNative.DataSize = (uint)sourceData.Length;
                sourceTextureNative.Data = sourceDataHandle.AddrOfPinnedObject();

                destinationDataHandle = GCHandle.Alloc(destinationData, GCHandleType.Pinned);
                destinationTextureNative.DataSize = (uint)destinationData.Length;
                destinationTextureNative.Data = destinationDataHandle.AddrOfPinnedObject();

                error = Delegates.ConvertTexture(
                    ref sourceTextureNative,
                    ref destinationTextureNative,
                    ref compressOptionsNative,
                    IntPtr.Zero);
            }
            finally
            {
                if (destinationDataHandle.IsAllocated == true)
                {
                    destinationDataHandle.Free();
                }

                if (sourceDataHandle.IsAllocated == true)
                {
                    sourceDataHandle.Free();
                }
            }

            Convert(ref sourceTextureNative, ref sourceTexture);
            Convert(ref destinationTextureNative, ref destinationTexture);
            return error;
        }
    }
}
