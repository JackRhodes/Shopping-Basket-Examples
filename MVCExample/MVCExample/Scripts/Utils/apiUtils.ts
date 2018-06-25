function postData(data: any, url: string): Promise<Response> {

    let postData: Object = {
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
        .then(response => response.json())
        .catch(e => console.log(e));
}