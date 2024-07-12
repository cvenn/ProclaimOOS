# ProclaimOOS
Takes a Proclaim Presentation Backup file (.prs) and produces an HTML Order of Service document.

Usage:
- From Proclaim, make a backup of the presentation (File, Back up Presentation). 
- Save the file to the Downloads folder.
- Click 'Show in folder' to find the file.
- Double-click on the downloaded file
	- The generated order of service will be opened by the default HTML application (usually a web browser)

Configuration:
- Content filtering, layout and styles can all be changed by editing files in %LocalAppData%\cvImaging\ProclaimOOS\css
- style.css contains the styles used by the utility
- Presentation.cshtml is a razor template containing
	- Logic (code) for item selection, style selection and text mapping
	- The HTML layout template
