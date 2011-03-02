using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using instagrammer;

public static class HtmlHelpers {

    public static string FormatReadableDate(this HtmlHelper helper, DateTime otherTime) {

        TimeSpan dateDiff = otherTime - DateTime.Now;
        string dateStamp = string.Empty;

        if (dateDiff.Days > 0)
            dateStamp = string.Format("{0} d", dateDiff.Days);

        if (dateDiff.Hours > 0)
            dateStamp = string.Format("{0} h", dateDiff.Hours);

        if (dateDiff.Minutes > 0)
            dateStamp = string.Format("{0} m", dateDiff.Minutes);

        if (string.IsNullOrEmpty(dateStamp))
            dateStamp = otherTime.ToShortDateString();

        return dateStamp;
    }

    public static string DelimetedListOfUsers(this HtmlHelper helper, IList<InstagramUser> users) {
        if (users.Count == 0)
            return "";

        StringBuilder sb = new StringBuilder();
        foreach (InstagramUser user in users) {
            sb.AppendFormat("{0}, ", user.username);
        }

        return sb.ToString().Remove(sb.Length - 2);
    }
}
