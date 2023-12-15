const token = localStorage.getItem('token');

async function getDataWithBearerToken(url, token) {
    try {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'accept': 'text/plain'
            }
        });

        if (response.ok) {
            console.log(response);
            console.log(true);
            return true;
        } else {
            console.log(false);
            return false;
        }
    } catch (error) {
        console.error(error);
        console.log(false);
        return false;
    }
}
async function checkToken() {
    let valid = await getDataWithBearerToken("http://localhost:5149/api/Auth", token);
    let jsonPayload;
    try {

        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        jsonPayload = decodeURIComponent(atob(base64).split('').map((c) => {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
    }
    catch {
        console.log("Ooops")
        if (valid === false) {
            console.log("401 Unauthorized");
            window.location.href = '../html/html401.html';
        }
    }
    decodedToken = JSON.parse(jsonPayload);
}
checkToken();

const openMenu = document.querySelector("#open-menu");
const closeMenu = document.querySelector("#close-menu");
const aside = document.querySelector("aside");


