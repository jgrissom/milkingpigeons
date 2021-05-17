window.onload = ()=>{
    const colors = ['btn-danger', 'btn-success', 'btn-primary', 'btn-warning'];
    const pin = new URLSearchParams(document.location.search).get("pin");
    let html = "";
    for (let i = 0; i < pin.length; i++) {
        html += '<button type="button" class="btn ' + colors[pin[i]] + '">' + (parseInt(pin[i])) + '</button> ';
    }
    document.getElementById('pin').innerHTML = html;
    // start timer to check for team registrations
    checkTeams();
    let intervalId = setInterval( () => {
        checkTeams();
    }, 3000 );
}
async function checkTeams(){
    const id = new URLSearchParams(document.location.search).get("id");
    const teams = await getData('api/teamchallenge/' + id);
    const teamsList = document.getElementById('teams');
    let html = '';
    if (teams && teams.length > 0) {
        teams.forEach((team) => {
            html += '<li class="list-group-item">' + team.name + '</li>'
        });
        teamsList.innerHTML = html;
    }
}
