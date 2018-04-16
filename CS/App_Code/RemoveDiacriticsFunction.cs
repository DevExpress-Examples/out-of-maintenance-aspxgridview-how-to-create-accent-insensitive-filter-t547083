using DevExpress.Data.Filtering;
using System;
using System.Globalization;
using System.Text;

public sealed class RemoveDiacriticsFunction : ICustomFunctionOperator {
    object ICustomFunctionOperator.Evaluate(params object[] operands) {
        StringBuilder sb = new StringBuilder();
        string src = (string)operands[0];
        foreach(char c in src.Normalize(NormalizationForm.FormKD))
            switch(CharUnicodeInfo.GetUnicodeCategory(c)) {
                case UnicodeCategory.NonSpacingMark:
                case UnicodeCategory.SpacingCombiningMark:
                case UnicodeCategory.EnclosingMark:
                    //do nothing
                    break;
                default:
                    sb.Append(c);
                    break;
            }

        return sb.ToString();
    }

    string ICustomFunctionOperator.Name {
        get { return "RemoveDiacritics"; }
    }

    Type ICustomFunctionOperator.ResultType(params Type[] operands) {
        return typeof(string);
    }
}