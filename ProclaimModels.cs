using System.Text.RegularExpressions;

namespace ProclaimOOS;
public class Presentation {
    public string? title;
    public DateOnly? dateGiven;
    public TimeOnly? startTime;
    public List<PresentationItem> items = [];

    public string Title => title ?? "";

    //    public void ToHtml(StreamWriter sw) {
    //        sw.WriteLine(@$"<html>");
    //        sw.WriteLine(@$"<head>");
    //        sw.WriteLine(@$"<title>{Title}</title>");
    //        sw.WriteLine(@$"<link rel=""stylesheet"" type=""text/css"" href=""css/style.css"">");
    //        sw.WriteLine(@$"</head>");
    //        sw.WriteLine(@$"<body>");

    //        sw.WriteLine(@$"<h1>{Title}</h1>");

    //        sw.WriteLine(@$"<table class=""data_table"">");
    //        sw.WriteLine(@$"<thead class=""header"">");
    //        sw.WriteLine(@$"<tr>");
    //        sw.WriteLine(@$"<td>Category</td>");
    //        sw.WriteLine(@$"<td>Description</td>");
    //        sw.WriteLine(@$"</tr>");
    //        sw.WriteLine(@$"</thead>");

    //        sw.WriteLine(@$"<tbody>");

    //        items.ForEach(i => i.ToHtml(sw));

    //        sw.WriteLine(@$"</tbody>");
    //        sw.WriteLine(@$"</table>");
    //        sw.WriteLine(@$"</body>");
    //        sw.WriteLine(@$"</html>");
    //    }
}

public class PresentationItem {
    public string? kind;
    public string? title;
    //public string? id;
    //public string? notes;

    public string Kind => kind ?? "";
    public string Title => title ?? "";

    public bool IncludeItem {
        get {
            if (Regex.IsMatch(Title, @"Slide \d+")) {
                return false;
            }
            return title switch {
                "Blank" => false,
                "End" => false,
                _ => true
            };
        }
    }

    public string MappedKind => Kind switch {
            "Content" => "",
            "ImageSlideshow" => "Slides",
            "Grouping" => "Slides",
            "ConfidenceTimerCue" => "Cue",
            "BiblePassage" => "Bible Passage",
            "SongLyrics" => "Song",
            "Video" => "Video",
            _ => Kind
        };
    

    public string MappedStyle => Kind switch {
            "SongLyrics" => @"data_IC",
            "Video" => @"data_HP",
            _ => ""
        };

    //public void ToHtml(StreamWriter sw) {
    //    if (IncludeItem) {
    //        sw.WriteLine(@$"<tr{MappedStyle}>");
    //        sw.WriteLine(@$"<td class=""data_BC"">{MappedKind}</td>");
    //        sw.WriteLine(@$"<td>{Title}</td>");
    //        sw.WriteLine(@$"</tr>");
    //    }
    //}

}
