/*function setAge()
{
    var birthDate = document.getElementById("BirthDate").value;

    
    console.log(birthDate);
    document.getElementById("Age").value = 15;

}
*/

function setAge() {


    let bday = document.getElementById("BirthDate").value;

    if (bday == "" || bday == null) {

        alert("set birthdate , age will be automatically set")
        document.getElementById("Age").value = null;

    }
    else {
        let d = new Date(bday);
        let today = new Date();
        console.log(today.getFullYear());

        console.log(d.getFullYear());


        let age = today.getFullYear() - d.getFullYear();
        document.getElementById("Age").value = age;
    }
}

function validateConfirmationPassword() {

    let confirmPassword = document.getElementById("confirmPassword").value;
  let password = document.getElementById("password").value;
  let isValid = false;
  if (confirmPassword == "") {
    isValid = false;
  }
  else if (confirmPassword != password) {
    isValid = false;
  }
  else if (confirmPassword != "" && confirmPassword == password) {
    isValid = true;
  }

    if (!isValid) {
        document.getElementById("confirmPassword").value = "";
    } 


}

function clearConfirmPassword() {
    document.getElementById("confirmPassword").value = "";
}


