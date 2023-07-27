function getDynamicTextbox() {
    return '<div>' +
    '<h6>Experience</h6>'+
        '<div class="form-group m-2">' +
        '<label for="ExperienceList">JobTitle</label>' +
        '<input type="text" name="ExperienceList[].JobTitle" class="form-control" />' +
        '</div>' +
        '<div class="form-group m-2">' +
        '<label for="ExperienceList">Company</label>' +
        '<input type="text" name="ExperienceList[].Company" class="form-control" />' +
        '</div>' +
        '<div class="form-group m-2">' +
        '<label for="ExperienceList">City</label>' +
        '<input type="text" name="ExperienceList[].City" class="form-control" />' +
        '</div>' +
        '<div class="form-group m-2">' +
        '<label for="ExperienceList">Country</label>' +
        '<input type="text" name="ExperienceList[].Country" class="form-control" />' +
        '</div>' +
        '<div class="form-group m-2">' +
        '<label for="ExperienceList">StartDate</label>' +
        '<input type="text" name="ExperienceList[].StartDate" class="form-control" />' +
        '</div>' +
        '<div class="form-group m-2">' +
        '<label for="ExperienceList">EndDate</label>' +
        '<input type="text" name="ExperienceList[].EndDate" class="form-control" />' +
        '</div>' +
        '<div class="form-group m-2">' +
        '<label for="ExperienceList">Description</label>' +
        '<input type="text" name="ExperienceList[].Description" class="form-control" />' +
        '</div>' +
        '<button class="btn btn-danger m-2" type="button" onclick="remove(this)" value="remove"> Remove</button>' +
        '</div>'
   
}*/
function addExperience() {
    var div = document.createElement('div');
    div.innerHTML = getDynamicTextbox();
    document.getElementById('Experience-container').appendChild(div);
}

function remove(button) {
    button.parentNode.remove();
}


