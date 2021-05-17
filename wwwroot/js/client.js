async function getData(url) {
    // fetch data from api
    try {
        let res = await fetch(url);
        if (res.status == 200) {
            let data = await res.json();
            return await data;
        }
        // TODO: customize error
        console.log(res.status);
        return null;
    } catch (error) {
        // TODO: customize error
        console.log(error);
    }
}
