ace.sidebar_hoverable = function (e) {
        function a(a) {
var t = e(a);
a.style.removeProperty("top"),
    a.style.removeProperty("bottom");
var s = null;
ace.vars.minimized && (s = a.parentNode.querySelector(".menu-text")) && s.style.removeProperty("margin-top");
var i = t.offset(),
    n = ace.helper.scrollTop(),
    o = !1,
    d = n;
l && (d += r.clientHeight + 1);
var h = a.scrollHeight;
s && (h += 40, i.top -= 40);
var u, v = parseInt(i.top + h);
if ((u = v - (window.innerHeight + n - 50)) > 0) {
    if (c > h - u && i.top - u > d)  {
		a.style.top = "auto", a.style.bottom = "-10px", s && (s.style.marginTop = -(h - 50) + "px", o = !0);
    } else {
        i.top - u < d && (u = i.top - d), v - u < i.top + c && (u -= c);
        var p = s ? 40 : 20;
        u > p && (a.style.top = -u + "px", s && (s.style.marginTop = -u + "px", o = !0))
    }
}
var f = this.className.lastIndexOf("pull_up");
o ? -1 == f && (this.className = this.className + " pull_up") : f >= 0 && (this.className = this.className.replace(/(^|\s)pull_up($|\s)/, "")),