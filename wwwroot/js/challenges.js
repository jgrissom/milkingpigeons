window.onload= async()=>{
    const categories = await getData('api/category');
    document.getElementById('loading').style.display = 'none';
    // populate list of categories
    let html = '';
    categories.forEach(category => {
        html += '<button type="button" class="list-group-item list-group-item-action category" data-id="' + category.id + '">' + category.name + '</button>'
    });
    document.getElementById('category').innerHTML = html;

    document.getElementById('category').onclick = function(event) {
        const button = event.target.closest('button');
        if (!button) return;
        // remove active class from all buttons
        document.querySelectorAll('button.category').forEach((el) => {
        el.classList.remove('active');
        });
        // add active class to selected button
        button.classList.add('active');
        // show challenges for selected category
        let challengeHtml = '';
        const id = parseInt(button.dataset.id);
        const challenges = categories.filter(cat => cat.id == id)[0].challenges;
        challenges.forEach((challenge) => {
        challengeHtml += '<a href="teams.html?id=' + challenge.id + '" class="list-group-item list-group-item-action">' + challenge.name + '</a>';
        });
        document.getElementById('challengesList').style.display = 'block';
        document.getElementById('challenge').innerHTML = challengeHtml;
    }
}
async function getData(url) {
    // fetch data from api
    try {
        let res = await fetch(url);
        let data = await res.json();
        return await data;
    } catch (error) {
        // TODO: customize error
        console.log(error);
    }
}
