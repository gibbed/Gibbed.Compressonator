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
        [StructLayout(LayoutKind.Sequential)]
        private struct CompressOptionsNative
        {
            public uint Size;
            public bool UseChannelWeighting;
            public float WeightingRed;
            public float WeightingGreen;
            public float WeightingBlue;
            public bool UseAdaptiveWeighting;
            public bool DXT1UseAlpha;
            public bool UseGPUDecompress;
            public bool UseCGCompress;
            public byte AlphaThreshold;
            public bool DisableMultiThreading;
            public CompressionSpeed Speed;
            public GPUDecode GPUDecode;
            public ComputeType EncodeWith;
            public uint NumberOfThreads;
            public float Quality;
            public bool RestrictColour;
            public bool RestrictAlpha;
            public uint ModeMask;
            public int NumberOfCommands;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public AMDCommandSet[] CommandSet;
            public float InputDefog;
            public float InputExposure;
            public float InputKneeLow;
            public float InputKneeHigh;
            public float InputGamma;
            public int Level;
            public int PositionBits;
            public int TextureCoordinateBits;
            public int NormalBits;
            public int GenericBits;
            public int VcacheSize;
            public int VcacheFIFOSize;
            public float OverdrawACMR;
            public int SimplifyLOD;
            public bool VertexFetch;
            public Format SourceFormat;
            public Format DestinationFormat;
            public bool FormatSupportGPU;
            public IntPtr PrintInfo;
        }
    }
}
