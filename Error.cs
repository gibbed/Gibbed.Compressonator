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
        public enum Error : uint
        {
            /// <summary>
            /// Ok.
            /// </summary>
            OK = 0,

            /// <summary>
            /// The conversion was aborted.
            /// </summary>
            Aborted,

            /// <summary>
            /// The source texture is invalid.
            /// </summary>
            InvalidSourceTexture,

            /// <summary>
            /// The destination texture is invalid.
            /// </summary>
            InvalidDestinationTexture,

            /// <summary>
            /// The source format is not a supported format.
            /// </summary>
            UnsupportedSourceFormat,

            /// <summary>
            /// The destination format is not a supported format.
            /// </summary>
            UnsupportedDestinationFormat,

            /// <summary>
            /// The gpu hardware is not supported.
            /// </summary>
            UnsupportedGPUASTCDecode,

            /// <summary>
            /// The gpu hardware is not supported.
            /// </summary>
            UnsupportedGPUBasisDecode,

            /// <summary>
            /// The source and destination texture sizes do not match.
            /// </summary>
            SizeMismatch,

            /// <summary>
            /// Compressonator was unable to initialize the codec needed for conversion.
            /// </summary>
            UnableToInitializeCodec,

            /// <summary>
            /// GPU_Decode Lib was unable to initialize the codec needed for decompression.
            /// </summary>
            UnableToInitializeDecompressLib,

            /// <summary>
            /// Compute Lib was unable to initialize the codec needed for compression.
            /// </summary>
            UnableToInitializeComputeLib,

            /// <summary>
            /// Error in compressing destination texture.
            /// </summary>
            CompressDestination,

            /// <summary>
            /// Memory Error: allocating MIPSet compression level data buffer.
            /// </summary>
            MemoryAllocationForMipSet,

            /// <summary>
            /// The destination Codec Type is unknown! In SDK refer to GetCodecType()
            /// </summary>
            UnknownDestinationFormat,

            /// <summary>
            /// Failed to setup Host for processing.
            /// </summary>
            FailedHostSetup,

            /// <summary>
            /// The required plugin library was not found.
            /// </summary>
            PluginFileNotFound,

            /// <summary>
            /// The requested file was not loaded.
            /// </summary>
            UnableToLoadFile,

            /// <summary>
            /// Request to create an encoder failed.
            /// </summary>
            UnableToCreateEncoder,

            /// <summary>
            /// Unable to load an encode library.
            /// </summary>
            UnableToLoadEncoder,

            /// <summary>
            /// No shader code is available for the requested framework.
            /// </summary>
            NoShaderCodeDefined,

            /// <summary>
            /// The GPU device selected does not support compute.
            /// </summary>
            GPUDoesNotSupportcompute,

            /// <summary>
            /// An unknown error occurred.
            /// </summary>
            Unknown,
        }
    }
}
