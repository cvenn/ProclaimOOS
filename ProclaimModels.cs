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
}
