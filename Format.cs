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
        public enum Format : uint
        {
            /// <summary>
            /// Undefined texture format.
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// ARGB format with 8-bit fixed channels.
            /// </summary>
            ARGB_8888,

            /// <summary>
            /// ABGR format with 8-bit fixed channels.
            /// </summary>
            ABGR_8888,

            /// <summary>
            /// RGBA format with 8-bit fixed channels.
            /// </summary>
            RGBA_8888,

            /// <summary>
            /// BGRA format with 8-bit fixed channels.
            /// </summary>
            BGRA_8888,

            /// <summary>
            /// RGB format with 8-bit fixed channels.
            /// </summary>
            RGB_888,

            /// <summary>
            /// BGR format with 8-bit fixed channels.
            /// </summary>
            BGR_888,

            /// <summary>
            /// Two component format with 8-bit fixed channels.
            /// </summary>
            RG_8,
            /// <summary>
            /// Single component format with 8-bit fixed channels.
            /// </summary>
            R_8,

            /// <summary>
            /// ARGB format with 10-bit fixed channels for color & a 2-bit fixed channel for alpha.
            /// </summary>
            ARGB_2101010,

            /// <summary>
            /// ARGB format with 16-bit fixed channels.
            /// </summary>
            ARGB_16,

            /// <summary>
            /// ABGR format with 16-bit fixed channels.
            /// </summary>
            ABGR_16,

            /// <summary>
            /// RGBA format with 16-bit fixed channels.
            /// </summary>
            RGBA_16,

            /// <summary>
            /// BGRA format with 16-bit fixed channels.
            /// </summary>
            BGRA_16,

            /// <summary>
            /// Two component format with 16-bit fixed channels.
            /// </summary>
            RG_16,

            /// <summary>
            /// Single component format with 16-bit fixed channels.
            /// </summary>
            R_16,

            /// <summary>
            /// RGB format with 9-bit floating point each channel and shared 5 bit exponent
            /// </summary>
            RGBE_32F,

            /// <summary>
            /// ARGB format with 16-bit floating-point channels.
            /// </summary>
            ARGB_16F,

            /// <summary>
            /// ABGR format with 16-bit floating-point channels.
            /// </summary>
            ABGR_16F,

            /// <summary>
            /// RGBA format with 16-bit floating-point channels.
            /// </summary>
            RGBA_16F,

            /// <summary>
            /// BGRA format with 16-bit floating-point channels.
            /// </summary>
            BGRA_16F,

            /// <summary>
            /// Two component format with 16-bit floating-point channels.
            /// </summary>
            RG_16F,

            /// <summary>
            /// Single component with 16-bit floating-point channels.
            /// </summary>
            R_16F,

            /// <summary>
            /// ARGB format with 32-bit floating-point channels.
            /// </summary>
            ARGB_32F,

            /// <summary>
            /// ABGR format with 32-bit floating-point channels.
            /// </summary>
            ABGR_32F,

            /// <summary>
            /// RGBA format with 32-bit floating-point channels.
            /// </summary>
            RGBA_32F,

            /// <summary>
            /// BGRA format with 32-bit floating-point channels.
            /// </summary>
            BGRA_32F,

            /// <summary>
            /// RGB format with 32-bit floating-point channels.
            /// </summary>
            RGB_32F,

            /// <summary>
            /// BGR format with 32-bit floating-point channels.
            /// </summary>
            BGR_32F,

            /// <summary>
            /// Two component format with 32-bit floating-point channels.
            /// </summary>
            RG_32F,

            /// <summary>
            /// Single component with 32-bit floating-point channels.
            /// </summary>
            R_32F,

            /// <summary>
            /// ASTC (Adaptive Scalable Texture Compression) open texture compression standard
            /// </summary>
            ASTC,

            /// <summary>
            /// Single component compression format using the same technique as DXT5 alpha. Four bits per pixel.
            /// </summary>
            ATI1N,

            /// <summary>
            /// Two component compression format using the same technique as DXT5 alpha. Designed for compression of tangent space normal maps. Eight bits per pixel.
            /// </summary>
            ATI2N,

            /// <summary>
            /// Two component compression format using the same technique as DXT5 alpha. The same as ATI2N but with the channels swizzled. Eight bits per pixel.
            /// </summary>
            ATI2N_XY,

            /// <summary>
            /// ATI2N like format using DXT5. Intended for use on GPUs that do not natively support ATI2N. Eight bits per pixel.
            /// </summary>
            ATI2N_DXT5,

            /// <summary>
            /// CMP - a compressed RGB format.
            /// </summary>
            ATC_RGB,

            /// <summary>
            /// CMP - a compressed ARGB format with explicit alpha.
            /// </summary>
            ATC_RGBA_Explicit,

            /// <summary>
            /// CMP - a compressed ARGB format with interpolated alpha.
            /// </summary>
            ATC_RGBA_Interpolated,

            /// <summary>
            /// A four component opaque (or 1-bit alpha) compressed texture format for Microsoft DirectX10. Identical to DXT1.  Four bits per pixel.
            /// </summary>
            BC1,

            /// <summary>
            /// A four component compressed texture format with explicit alpha for Microsoft DirectX10. Identical to DXT3. Eight bits per pixel.
            /// </summary>
            BC2,

            /// <summary>
            /// A four component compressed texture format with interpolated alpha for Microsoft DirectX10. Identical to DXT5. Eight bits per pixel.
            /// </summary>
            BC3,

            /// <summary>
            /// A single component compressed texture format for Microsoft DirectX10. Identical to ATI1N. Four bits per pixel.
            /// </summary>
            BC4,

            /// <summary>
            /// A two component compressed texture format for Microsoft DirectX10. Identical to ATI2N_XY. Eight bits per pixel.
            /// </summary>
            BC5,

            /// <summary>
            /// BC6H compressed texture format (UF)
            /// </summary>
            BC6H,

            /// <summary>
            /// BC6H compressed texture format (SF)
            /// </summary>
            BC6H_SF,

            /// <summary>
            /// BC7  compressed texture format
            /// </summary>
            BC7,

            /// <summary>
            /// An DXTC compressed texture matopaque (or 1-bit alpha). Four bits per pixel.
            /// </summary>
            DXT1,

            /// <summary>
            ///   DXTC compressed texture format with explicit alpha. Eight bits per pixel.
            /// </summary>
            DXT3,

            /// <summary>
            ///   DXTC compressed texture format with interpolated alpha. Eight bits per pixel.
            /// </summary>
            DXT5,

            /// <summary>
            /// DXT5 with the red component swizzled into the alpha channel. Eight bits per pixel.
            /// </summary>
            DXT5_xGBR,

            /// <summary>
            /// Swizzled DXT5 format with the green component swizzled into the alpha channel. Eight bits per pixel.
            /// </summary>
            DXT5_RxBG,

            /// <summary>
            /// Swizzled DXT5 format with the green component swizzled into the alpha channel & the blue component swizzled into the green channel. Eight bits per pixel.
            /// </summary>
            DXT5_RBxG,

            /// <summary>
            /// Swizzled DXT5 format with the green component swizzled into the alpha channel & the red component swizzled into the green channel. Eight bits per pixel.
            /// </summary>
            DXT5_xRBG,

            /// <summary>
            /// Swizzled DXT5 format with the blue component swizzled into the alpha channel. Eight bits per pixel.
            /// </summary>
            DXT5_RGxB,

            /// <summary>
            /// Two-component swizzled DXT5 format with the red component swizzled into the alpha channel & the green component in the green channel. Eight bits per pixel.
            /// </summary>
            DXT5_xGxR,

            /// <summary>
            /// ETC   GL_COMPRESSED_RGB8_ETC2  backward compatible
            /// </summary>
            ETC_RGB,

            /// <summary>
            /// ETC2  GL_COMPRESSED_RGB8_ETC2
            /// </summary>
            ETC2_RGB,

            /// <summary>
            /// ETC2  GL_COMPRESSED_SRGB8_ETC2
            /// </summary>
            ETC2_SRGB,

            /// <summary>
            /// ETC2  GL_COMPRESSED_RGBA8_ETC2_EAC
            /// </summary>
            ETC2_RGBA,

            /// <summary>
            /// ETC2  GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2
            /// </summary>
            ETC2_RGBA1,

            /// <summary>
            /// ETC2  GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC
            /// </summary>
            ETC2_SRGBA,

            /// <summary>
            /// ETC2  GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2
            /// </summary>
            ETC2_SRGBA1,

            PVRTC,

            /// <summary>
            /// GTC   Fast Gradient Texture Compressor
            /// </summary>
            GTC,

            /// <summary>
            /// BASIS compression
            /// </summary>
            BASIS,
        }
    }
}
