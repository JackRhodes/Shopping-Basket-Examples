function postData(data, url) {
    var postData = {
        productId: data
    };
    console.log(postData);
    return fetch(url, {
        method: "POST",
        body: JSON.stringify(postData),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(function (response) { return response.json(); })
        .catch(function (e) { return console.log(e); });
}
//# sourceMappingURL=apiUtils.js.map