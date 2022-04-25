using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace API;

public class CsvOutputFormatter : TextOutputFormatter
{
	public CsvOutputFormatter()
	{
		SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
		SupportedEncodings.Add(Encoding.UTF8);
		SupportedEncodings.Add(Encoding.Unicode);
	}

	protected override bool CanWriteType(Type? type)
	{
		if (typeof(SchoolDto).IsAssignableFrom(type)
			|| typeof(IEnumerable<SchoolDto>).IsAssignableFrom(type))
		{
			return base.CanWriteType(type);
		}

		return false;
	}

	public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
		Encoding selectedEncoding)
	{
		var response = context.HttpContext.Response;
		var buffer = new StringBuilder();

		if (context.Object is IEnumerable<SchoolDto>)
		{
			foreach (var school in (IEnumerable<SchoolDto>)context.Object)
			{
				FormatCsv(buffer, school);
			}
		}
		else
		{
			FormatCsv(buffer, (SchoolDto)context.Object);
		}

		await response.WriteAsync(buffer.ToString());
	}

	private static void FormatCsv(StringBuilder buffer, SchoolDto school)
	{
		buffer.AppendLine($"{school.Id},\"{school.Name},\"{school.FullAddress}\"");
	}

}
