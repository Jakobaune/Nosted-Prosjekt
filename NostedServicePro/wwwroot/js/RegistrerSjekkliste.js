
document.getElementById('completeChecklist').addEventListener('click', function (event) {
    var allRadioGroupsChecked = true;
    var allTextInputFilled = true;

    // Liste over alle radio-grupper
    var radioGroups = ['ClutchLameller', 'Bremser', 'LagerTrommel', 'PTOOpplagring', 'Kjedestrammer', 'Wire', 'PlnlonLager', 'KilleKjedehjul', 'HydraulikkSylinderLekkasje', 'SlangerSkaderLekkasje', 'TestHydraulikkblokk', 'SkiftOljeTank', 'SkiftOljeGirboks', 'RingsyllingerSkiftTelnlnger', 'BremsesylingerSkiftTelninger', 'LedningsnettVinsj', 'SjekkTestRadio', 'SjekkTestKnappekasse'];

    // Valider radioknapper
    for (var i = 0; i < radioGroups.length; i++) {
        var groupName = radioGroups[i];
        if (!$('input[name="' + groupName + '"]:checked').val()) {
            allRadioGroupsChecked = false;
            break;
        }
    }

    // Liste over alle tekstinput under "Funksjonstesting", inkludert "SjekkListeFullførtAv"
    var textInputs = ['XXBar', 'TestVinsjAlleFunksjoner', 'TrekkraftKn', 'BremsekraftKn', 'Arbeidstimer', 'Kommentar', 'SjekkListeFullførtAv'];

    // Valider tekstinput
    for (var j = 0; j < textInputs.length; j++) {
        var inputId = textInputs[j];
        if (!$('#' + inputId).val().trim()) {
            allTextInputFilled = false;
            break;
        }
    }

    if (!allRadioGroupsChecked || !allTextInputFilled) {
        event.preventDefault(); // Forhindrer skjemaet i å bli sendt
        alert('Alle sjekkpunkter og tekstfelt må være utfylt for å fullføre sjekklisten.');
    }
});