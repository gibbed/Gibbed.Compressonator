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
        public struct Texture
        {
            /// <summary>
            /// Width of the texture.
            /// </summary>
            public uint Width;

            /// <summary>
            /// Height of the texture.
            /// </summary>
            public uint Height;

            /// <summary>
            /// Distance to start of next line, necessary only for uncompressed textures.
            /// </summary>
            public uint Pitch;

            /// <summary>
            /// Format of the texture.
            /// </summary>
            public Format Format;

            /// <summary>
            /// If the "format" is Basis; A optional target format can be set here (default is BC1).
            /// It can also be conditionally set runtime.
            /// </summary>
            public Format TranscodeFormat;

            /// <summary>
            /// If the source is a compressed format, specify its block dimensions.
            /// Default is 4.
            /// </summary>
            public byte BlockHeight;

            /// <summary>
            /// If the source is a compressed format, specify its block dimensions.
            /// Default is 4.
            /// </summary>
            public byte BlockWidth;

            /// <summary>
            /// If the source is a compressed format, specify its block dimensions.
            /// For ASTC this is the z setting.
            /// Default is 1.
            /// </summary>
            public byte BlockDepth;

            /// <summary>
            /// The texture data to process, this can be the image source or a specific MIP level.
            /// </summary>
            public byte[] Data;
        }
    }
}
