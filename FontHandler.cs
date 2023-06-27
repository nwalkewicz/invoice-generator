using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoice_generator.Properties;
using PdfSharp.Fonts;

namespace invoice_generator {
  public class JBFontResolver : IFontResolver {
    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic) {
      // Ignore case of font names
      string name = familyName.ToLower().TrimEnd('#');

      // Handle known fonts
      switch (name) {
        case "jetbrains mono nl":
          if (isBold) {
            if (isItalic)
              return new FontResolverInfo("JetBrains Mono NL#bi");
            return new FontResolverInfo("JetBrains Mono NL#b");
          }
          if (isItalic)
            return new FontResolverInfo("JetBrains Mono NL#i");
          return new FontResolverInfo("JetBrains Mono NL#");
      }

      // Pass everything else to the default handler
      return PlatformFontResolver.ResolveTypeface(familyName, isBold, isItalic);
    }

    public byte[]? GetFont(string faceName) {
      switch (faceName) {
        case "JetBrains Mono NL#":
          return Resources.JetBrainsMonoNL_Regular;

        case "JetBrains Mono NL#b":
          return Resources.JetBrainsMonoNL_Bold;

        case "JetBrains Mono NL#i":
          return Resources.JetBrainsMonoNL_Italic;

        case "JetBrains Mono NL#bi":
          return Resources.JetBrainsMonoNL_BoldItalic;
      }

      return null;
    }
  }
}
