using System.Text.RegularExpressions;

namespace ProclaimOOS;
public class Presentation {
    public string? title;
    public DateOnly? dateGiven;
    public TimeOnly? startTime;
    public List<PresentationItem> items = [];

    public string Title => title ?? "";
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

}
