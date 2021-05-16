window.onload=()=>{
    const colors = ['btn-danger', 'btn-success', 'btn-primary', 'btn-warning'];
    const pin = new URLSearchParams(document.location.search).get("pin");
    let html = "";
    for (let i = 0; i < pin.length; i++) {
        html += '<button type="button" class="btn ' + colors[pin[i]] + '">' + (parseInt(pin[i]) + 1) + '</button> ';
    }
    document.getElementById('pin').innerHTML = html;
}
