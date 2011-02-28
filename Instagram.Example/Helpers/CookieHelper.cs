using System.Web;
using instagrammer;

public static class CookieHelper {
    public static OAuthToken GetOAuthToken(string cookieId) {
        OAuthToken userToken = new OAuthToken();

        if (HttpContext.Current.Request.Cookies[cookieId] != null) {
            HttpCookie userCookie = HttpContext.Current.Request.Cookies.Get(cookieId);
            userToken.access_token = userCookie.Values["token"];
        }

        return userToken;
    }

}
