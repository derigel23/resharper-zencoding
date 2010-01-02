using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JetBrains.ReSharper.PowerToys.ZenCoding.Options.Model.Handlers
{
  internal class RegexPatternHandler : IPatternHandler
  {
    readonly IDictionary<string, Regex> _cache = new Dictionary<string, Regex>();

    public bool Matches(FileAssociation fileAssociation, string fileName)
    {
      if (!fileAssociation.Enabled)
      {
        return false;
      }

      if (fileAssociation.PatternType != PatternType.Regex)
      {
        return false;
      }

      var expr = GetRegex(fileAssociation);

      return expr.IsMatch(fileName);
    }

    Regex GetRegex(FileAssociation fileAssociation)
    {
      if (_cache.ContainsKey(fileAssociation.Pattern))
      {
        return _cache[fileAssociation.Pattern];
      }

      return new Regex(fileAssociation.Pattern,
                       RegexOptions.Compiled |
                       RegexOptions.CultureInvariant |
                       RegexOptions.IgnoreCase |
                       RegexOptions.Singleline);
    }
  }
}