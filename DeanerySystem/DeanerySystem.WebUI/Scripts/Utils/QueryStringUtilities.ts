class QueryStringUtilities {
	public static updateQueryStringParameter(key: string, value: string, uri?: string): string {
		if (!uri) {
			uri = window.location.href;
		}
		var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
		var separator = uri.indexOf('?') !== -1 ? "&" : "?";
		if (uri.match(re)) {
			return uri.replace(re, '$1' + key + "=" + value + '$2');
		}
		else {
			return uri + separator + key + "=" + value;
		}
	}
}

export default QueryStringUtilities;
