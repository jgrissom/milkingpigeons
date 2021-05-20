async function getData(url) {
    // fetch data from api
    try {
        let res = await fetch(url);
        if (res.status == 200) {
            let data = await res.json();
            return await data;
        } else if (res.status == 204) {
            return null;
        }
        // TODO: customize error
        console.log(res.status);
        return null;
    } catch (error) {
        // TODO: customize error
        console.log(error);
    }
}
async function deleteData(url) {
    try {
        let res = await fetch(url, { method: 'DELETE' });
        if (res.status == 204) {
            return;
        }
        // TODO: customize error
        console.log(res.status);
        return null;
    } catch (error) {
        // TODO: customize error
        console.log(error);
    }
}
