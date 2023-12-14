const sign_in_btn = document.querySelector("#sign-in-btn");
const sign_up_btn = document.querySelector("#sign-up-btn");
const container = document.querySelector(".container");

sign_up_btn.addEventListener("click", () => {
  container.classList.add("sign-up-mode");
});

sign_in_btn.addEventListener("click", () => {
  container.classList.remove("sign-up-mode");
});

document.querySelector('#submit_register').addEventListener('click', async function(event) {
  event.preventDefault();
  const form = this.closest('form');
  const usernameInputRegister = document.querySelector('#username_register');
  const passwordInputRegister = document.querySelector('#password_register');
  const emailInputRegister = document.querySelector('#email_register');

  if (form.checkValidity()) {
    const usernameRegister = usernameInputRegister.value;
    const passwordRegister = passwordInputRegister.value;
    const emailRegister = emailInputRegister.value;
    console.log(emailRegister, usernameRegister, passwordRegister);
    register(emailRegister, usernameRegister, passwordRegister)
      .then(result => console.log(result))
      .catch(error => console.error(error));
      
  } else {
    form.reportValidity();
  }
});

async function register (email, user, password) {
  const url = "http://localhost:5149/api/Auth/register";
  let update = {
      email: email,
      username: user,
      password: password
      };
  const options = {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json',
          },
          body: JSON.stringify(update)
          };
  try {
      const response = await fetch(url, options);
      const result = await response.text();
      return (result);
  } catch (error) {
      console.error(error);
      return null;
  }
}

async function login (user, password) {
  const url = "http://localhost:5149/api/Auth/login";
  let update = {
      username: user,
      password: password,

      };
  const options = {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json',
          },
          body: JSON.stringify(update)
          };
  try {
      const response = await fetch(url, options);
      const result = await response.text();
      return (result);
  } catch (error) {
      console.error(error);
      return null;
  }
}

async function post(json, endpoint) {
  const url = `http://localhost:5149/api${endpoint}`;
  const options = {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json',
      },
      body: JSON.stringify(json)
  };
  try {
      const response = await fetch(url, options);
      const result = await response.json();
      return result;
  } catch (error) {
      console.error(error);
      return null;
  }
}

async function performEndpoint(arg1 = null, arg2 = null, arg3 = null) {
  const result = await post(arg1, arg2);
  console.log(result);
  return (result);
}

//LOGIN
document.querySelector('.sign-btn').addEventListener('click', async function (event) {
  event.preventDefault();
  const form = this.closest('form');
  const usernameInputLogin = document.querySelector('#username_login');
  const passwordInputLogin = document.querySelector('#password_login');

  if (form.checkValidity()) {
      const usernameLogin = usernameInputLogin.value;
      const passwordLogin = passwordInputLogin.value;
      let errorField;
      let errorText;
      try {
          const token = await login(usernameLogin, passwordLogin);
          if (token == "User not found." || token == "Wrong password." || token == null || token == undefined) {
              if (token == "Wrong password.") {
                  errorField = document.querySelector('#password_login');
                  errorText = document.createElement('span');
                  errorText.textContent = "Wrong password";
              } else {
                  errorField = document.querySelector('#username_login');
                  errorText = document.createElement('span');
                  errorText.textContent = "User not found";
                  console.log("User not found");
              }
              errorText.classList.add('error-message');
              const existingErrorMessage = document.querySelector('.error-message');
              if (existingErrorMessage) {
                  existingErrorMessage.remove();
              }
              errorField.parentNode.appendChild(errorText);
              console.log(token);
          } else {
              localStorage.setItem('token', token);
              let update = {
                  username: usernameLogin,
                  password: passwordLogin
              };
              let roles = await performEndpoint(update, "/Auth/rols");
              console.log(roles);
              if (roles.includes("Administrator")) {
                  console.log("rol Administrator");
                  localStorage.setItem("rol", "html/menu");
              }
              else if (roles.includes("Person")) {
                  console.log("rol Person");
                  localStorage.setItem("rol", "html/menu");
              }
              let h = `../${localStorage.getItem("rol")}.html`;
              console.log(h);
              window.location.href = h;
          }
      } catch (error) {
          console.error(error);
      }
  } else {
      form.reportValidity();
  }
});