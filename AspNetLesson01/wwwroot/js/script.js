
$(window).on('load', function () {

    fetch("/about-me")
        .then(r => r.json())
        .then(aboutMe => {
            $("#about-me h5.card-title").html(`${aboutMe.firstName} ${aboutMe.lastName}`)
            $("#about-me div.info").html(aboutMe.description)

            updateSkills("")
        })
})

let skillsContainer = $('ul#skills')



function updateSkills(query) {
    fetch(`/about-me/skills`, {
        method: "post",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ "query": query })
    })
        .then(r => r.json())
        .then(skills => {
            skillsContainer.empty()
            skills.forEach(s => {
                skillsContainer.append($(`<li><div>${s.title}</div><div class="progress"><div class="progress-bar" role="progressbar" style="width: ${s.experience}%" aria-valuenow="${s.experience}" aria-valuemin="0" aria-valuemax="100"></div></div></li>`))
            })
        })
}

$("input#search").on('input', e => {
    let searchText = $(e.target).val()
    updateSkills(searchText)
})


