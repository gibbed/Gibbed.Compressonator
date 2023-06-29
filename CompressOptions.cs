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

namespace Gibbed
{
    public static partial class Compressonator
    {
        public struct CompressOptions
        {
            /// <summary>
            /// Use channel weightings. With swizzled formats the weighting applies to the data within the specified channel not the channel itself.
            /// Channel weigthing is not implemented for BC6H and BC7.
            /// </summary>
            public bool UseChannelWeighting;

            /// <summary>
            /// The weighting of the Red or X Channel.
            /// </summary>
            public float WeightingRed;

            /// <summary>
            /// The weighting of the Green or Y Channel.
            /// </summary>
            public float WeightingGreen;

            /// <summary>
            /// The weighting of the Blue or Z Channel.
            /// </summary>
            public float WeightingBlue;

            /// <summary>
            /// Adapt weighting on a per-block basis.
            /// </summary>
            public bool UseAdaptiveWeighting;

            /// <summary>
            /// Encode single-bit alpha data. Only valid when compressing to DXT1 & BC1.
            /// </summary>
            public bool DXT1UseAlpha;

            /// <summary>
            /// Use GPU to decompress. Decode API can be changed by specified in DecodeWith parameter. Default is OpenGL.
            /// </summary>
            public bool UseGPUDecompress;

            /// <summary>
            /// Use SPMD/GPU to compress. Encode API can be changed by specified in EncodeWith parameter. Default is OpenCL.
            /// </summary>
            public bool UseCGCompress;

            /// <summary>
            /// The alpha threshold to use when compressing to DXT1 & BC1 with DXT1UseAlpha. Texels with an alpha value less than the threshold are treated as transparent.
            /// Note: When CompressionSpeed is not set to Normal AphaThreshold is ignored for DXT1 & BC1
            /// </summary>
            public byte AlphaThreshold;

            /// <summary>
            /// Disable multi-threading of the compression. This will slow the compression but can be useful if you're managing threads in your application.
            /// If set BC7 NumberOfThreads will default to 1 during encoding and then return back to its original value when done.
            /// </summary>
            public bool DisableMultiThreading;

            /// <summary>
            /// The trade-off between compression speed & quality.
            /// Notes:
            /// 1. This value is ignored for BC6H and BC7 (for BC7 the compression speed depends on fquaility value)
            /// 2. For 64 bit DXT1 to DXT5 and BC1 to BC5 CompressionSpeed is ignored and set to Noramal Speed
            /// 3. To force the use of CompressionSpeed setting regardless of Note 2 use Quality at 0.05
            /// </summary>
            public CompressionSpeed Speed;

            /// <summary>
            /// This value is set using DecodeWith argument (OpenGL, DirectX) default is OpenGL
            /// </summary>
            public GPUDecode GPUDecode;

            /// <summary>
            /// This value is set using EncodeWith argument, currently only OpenCL is used
            /// </summary>
            public ComputeType EncodeWith;

            /// <summary>
            /// Number of threads to initialize for BC7 encoding (Max up to 128). Default set to auto,
            /// </summary>
            public uint NumberOfThreads;

            /// <summary>
            /// Quality of encoding. This value ranges between 0.0 and 1.0.
            /// Setting quality above 0.0 gives the fastest, lowest quality encoding, 1.0 is the slowest, highest quality encoding.
            /// Default set to a low value of 0.05.
            /// </summary>
            public float Quality;

            /// <summary>
            /// This setting is a quality tuning setting for BC7 which may be necessary for convenience in some applications. Default set to false
            /// if set and the block does not need alpha it instructs the code not to use modes that have combined colour + alpha - this
            /// avoids the possibility that the encoder might choose an alpha other than 1.0 (due to parity) and cause something to
            /// become accidentally slightly transparent (it's possible that when encoding 3-component texture applications will assume that
            /// the 4th component can safely be assumed to be 1.0 all the time.)
            /// </summary>
            public bool RestrictColour;

            /// <summary>
            /// This setting is a quality tuning setting for BC7 which may be necessary for some textures. Default set to false,
            /// if set it will also apply restriction to blocks with alpha to avoid issues with punch-through or thresholded alpha encoding
            /// </summary>
            public bool RestrictAlpha;

            /// <summary>
            /// Mode to set BC7 to encode blocks using any of 8 different block modes in order to obtain the highest quality. Default set to 0xFF)
            /// You can combine the bits to test for which modes produce the best image quality.
            /// The mode that produces the best image quality above a set quality level (fquality) is used and subsequent modes set in the mask
            /// are not tested, this optimizes the performance of the compression versus the required quality.
            /// If you prefer to check all modes regardless of the quality then set the fquality to a value of 0.
            /// </summary>
            public uint ModeMask;

            /// <summary>
            /// ToneMap properties for float type image send into non float compress algorithm.
            /// </summary>
            public float InputDefog;

            /// <summary>
            /// ToneMap properties for float type image send into non float compress algorithm.
            /// </summary>
            public float InputExposure;

            /// <summary>
            /// ToneMap properties for float type image send into non float compress algorithm.
            /// </summary>
            public float InputKneeLow;

            /// <summary>
            /// ToneMap properties for float type image send into non float compress algorithm.
            /// </summary>
            public float InputKneeHigh;

            /// <summary>
            /// ToneMap properties for float type image send into non float compress algorithm.
            /// </summary>
            public float InputGamma;

            /// <summary>
            /// Draco setting: compression level (range 0-10: higher mean more compressed) - default 7.
            /// </summary>
            public int Level;

            /// <summary>
            /// Quantization bits for position - default 14.
            /// </summary>
            public int PositionBits;

            /// <summary>
            /// Quantization bits for texture coordinates - default 12.
            /// </summary>
            public int TextureCoordinateBits;

            /// <summary>
            /// Quantization bits for normal - default 10.
            /// </summary>
            public int NormalBits;

            /// <summary>
            /// Quantization bits for generic - default 8.
            /// </summary>
            public int GenericBits;

            /// <summary>
            /// For mesh vertices optimization, hardware vertex cache size. (value range 1- no limit as it allows users to simulate hardware cache size to find the most optimum size)- default is enabled with cache size = 16.
            /// </summary>
            public int VcacheSize;

            /// <summary>
            /// For mesh vertices optimization, hardware vertex cache size. (value range 1- no limit as it allows users to simulate hardware cache size to find the most optimum size)- default is disabled.
            /// </summary>
            public int VcacheFIFOSize;

            /// <summary>
            /// For mesh overdraw optimization,  optimize overdraw with ACMR (average cache miss ratio) threshold value specified (value range 1-3) - default is enabled with ACMR value = 1.05 (i.e. 5% worse).
            /// </summary>
            public float OverdrawACMR;

            /// <summary>
            /// simplify mesh using LOD (Level of Details) value specified.(value range 1- no limit as it allows users to simplify the mesh until the level they desired. Higher level means less triangles drawn, less details.).
            /// </summary>
            public int SimplifyLOD;

            /// <summary>
            /// optimize vertices fetch . boolean value 0 - disabled, 1-enabled. -default is enabled.
            /// </summary>
            public bool VertexFetch;

            public Format SourceFormat;
            public Format DestinationFormat;
            public bool FormatSupportGPU;

            public static CompressOptions Default()
            {
                CompressOptions instance;
                instance.UseChannelWeighting = false;
                instance.WeightingRed = instance.WeightingGreen = instance.WeightingBlue = default;
                instance.UseAdaptiveWeighting = false;
                instance.DXT1UseAlpha = false;
                instance.UseGPUDecompress = false;
                instance.UseCGCompress = false;
                instance.AlphaThreshold = default;
                instance.DisableMultiThreading = false;
                instance.Speed = CompressionSpeed.Normal;
                instance.GPUDecode = default;
                instance.EncodeWith = default;
                instance.NumberOfThreads = 0;
                instance.Quality = 0.05f;
                instance.RestrictColour = default;
                instance.RestrictAlpha = default;
                instance.ModeMask = 0xFF;
                instance.InputDefog = default;
                instance.InputExposure = default;
                instance.InputKneeLow = default;
                instance.InputKneeHigh = default;
                instance.InputGamma = default;
                instance.InputExposure = default;
                instance.Level = 7;
                instance.PositionBits = 14;
                instance.TextureCoordinateBits = 12;
                instance.NormalBits = 10;
                instance.GenericBits = 8;
                instance.VcacheSize = 16;
                instance.VcacheFIFOSize = 0;
                instance.OverdrawACMR = 1.05f;
                instance.SimplifyLOD = default;
                instance.VertexFetch = true;
                instance.SourceFormat = default;
                instance.DestinationFormat = default;
                instance.FormatSupportGPU = default;
                return instance;
            }
        }
    }
}
