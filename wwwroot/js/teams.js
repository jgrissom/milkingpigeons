let rows = 0;
const challengeId = new URLSearchParams(document.location.search).get("id");

window.onload = async function() {
    // display pin
    const colors = ['btn-danger', 'btn-success', 'btn-primary', 'btn-warning'];
    const pin = new URLSearchParams(document.location.search).get("pin");
    let html = "";
    for (let i = 0; i < pin.length; i++) {
        html += '<button type="button" class="btn ' + colors[pin[i]] + '">' + (parseInt(pin[i])) + '</button> ';
    }
    document.getElementById('pin').innerHTML = html;
    
    // const count = await getData('api/teamchallenge/' + challengeId + '/count');
    if (await getCount() > 0) {
        displayTeamList();
    }
    // start timer to check for team registrations
    let intervalId = setInterval( () => {
        checkCount();
    }, 3000 );
    // delegated event listener for unregister buttons
    document.getElementById('teams').onclick = function(event) {
        const button = event.target.closest('button');
        if (button) {
            deleteData('api/teamchallenge/' + button.dataset.id);
            displayTeamList();
        }
    };
}
async function checkCount() {
    if (await getCount() != rows) {
        displayTeamList();
    }
}
async function getCount(){
    return await getData('api/teamchallenge/' + challengeId + '/count');   
}
async function displayTeamList(){
    const teamChallenges = await getData('api/teamchallenge/' + challengeId);
    let html = '';
    if (teamChallenges){
        rows = teamChallenges.length;
        teamChallenges.forEach((tc) => {
            html += '<li class="list-group-item d-flex justify-content-between align-items-start"><div class="ms-2 me-auto">' + tc.name + '</div><button type="button" class="btn btn-danger btn-sm" data-id="' + tc.teamChallengeId + '">unregister</button></div>';
        });
    } else {
        rows = 0;
    }
    document.getElementById('teams').innerHTML = html;
}
