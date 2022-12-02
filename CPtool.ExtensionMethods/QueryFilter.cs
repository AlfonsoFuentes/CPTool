using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CPtool.ExtensionMethods
{
    public class QueryFilter
    {
        //
        // Resumen:
        //     Gets or sets the filter.
        //
        // Valor:
        //     The filter.
        public string Filter { get; set; } = "";

        //
        // Resumen:
        //     Gets or sets the filter parameters.
        //
        // Valor:
        //     The filter parameters.
        public object[]? FilterParameters { get; set; } = null!;

        //
        // Resumen:
        //     Gets or sets the order by.
        //
        // Valor:
        //     The order by.
        public string OrderBy { get; set; } = "";

        //
        // Resumen:
        //     Gets or sets the expand.
        //
        // Valor:
        //     The expand.
        public string Expand { get; set; } = "";

        //
        // Resumen:
        //     Gets or sets the select.
        //
        // Valor:
        //     The select.
        public string Select { get; set; } = "";

        //
        // Resumen:
        //     Gets or sets the skip.
        //
        // Valor:
        //     The skip.
        public int? Skip { get; set; }

        //
        // Resumen:
        //     Gets or sets the top.
        //
        // Valor:
        //     The top.
        public int? Top { get; set; }

        //
        // Resumen:
        //     Converts the query to OData query format.
        //
        // Parámetros:
        //   url:
        //     The URL.
        //
        // Devuelve:
        //     System.String.
        public string ToUrl(string url)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            if (Skip.HasValue)
            {
                dictionary.Add("$skip", Skip.Value);
            }

            if (Top.HasValue)
            {
                dictionary.Add("$top", Top.Value);
            }

            if (!string.IsNullOrEmpty(OrderBy))
            {
                dictionary.Add("$orderBy", OrderBy);
            }

            if (!string.IsNullOrEmpty(Filter))
            {
                dictionary.Add("$filter", UrlEncoder.Default.Encode(Filter));
            }

            if (!string.IsNullOrEmpty(Expand))
            {
                dictionary.Add("$expand", Expand);
            }

            if (!string.IsNullOrEmpty(Select))
            {
                dictionary.Add("$select", Select);
            }

            return string.Format("{0}{1}", url, dictionary.Any() ? ("?" + string.Join("&", dictionary.Select(delegate (KeyValuePair<string, object> a)
            {
                DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
                defaultInterpolatedStringHandler.AppendFormatted(a.Key);
                defaultInterpolatedStringHandler.AppendLiteral("=");
                defaultInterpolatedStringHandler.AppendFormatted<object>(a.Value);
                return defaultInterpolatedStringHandler.ToStringAndClear();
            }))) : "");
        }
    }
}
