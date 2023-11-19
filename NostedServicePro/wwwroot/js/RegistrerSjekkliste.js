function setBremserStatus(status) {
    // Finn det relevante HTML-elementet for Bremser
    var bremserElement = document.getElementById('bremserStatus');

    // Oppdater grensesnittet basert på valgt status
    switch (status) {
        case 'OK':
            bremserElement.innerHTML = 'Bremser er i god stand.';
            break;
        case 'Bør Skiftes':
            bremserElement.innerHTML = 'Bremser bør skiftes ut.';
            break;
        case 'Defekt':
            bremserElement.innerHTML = 'Bremser er defekte.';
            break;
        default:
            // Håndter andre tilfeller hvis nødvendig
            break;
    }
}

// Legg til dette i din RegistrerSjekkliste.js-fil

// Gjør noe med verdien 'status' for LagerTrommel
function setLagerTrommel(status) {
    // Finn det relevante HTML-elementet for LagerTrommel
    var lagerTrommelElement = document.getElementById('lagerTrommelStatus');

    // Oppdater grensesnittet basert på valgt status
    switch (status) {
        case 'OK':
            lagerTrommelElement.innerHTML = 'LagerTrommel er i god stand.';
            break;
        case 'Bør Skiftes':
            lagerTrommelElement.innerHTML = 'LagerTrommel bør skiftes ut.';
            break;
        case 'Defekt':
            lagerTrommelElement.innerHTML = 'LagerTrommel er defekt.';
            break;
        default:
            // Håndter andre tilfeller hvis nødvendig
            break;
    }
}


// Gjør noe med verdien 'status' for PTOOpplagring
function setPTOOpplagring(status) {
    // Finn det relevante HTML-elementet for PTOOpplagring
    var ptoOpplagringElement = document.getElementById('ptoOpplagringStatus');

    // Oppdater grensesnittet basert på valgt status
    switch (status) {
        case 'OK':
            ptoOpplagringElement.innerHTML = 'PTOOpplagring er i god stand.';
            break;
        case 'Bør Skiftes':
            ptoOpplagringElement.innerHTML = 'PTOOpplagring bør skiftes ut.';
            break;
        case 'Defekt':
            ptoOpplagringElement.innerHTML = 'PTOOpplagring er defekt.';
            break;
        default:
            // Håndter andre tilfeller hvis nødvendig
            break;
    }
}

// Gjør noe med verdien 'status' for Kjedestrammer
function setKjedestrammer(status) {
    var kjedestrammerElement = document.getElementById('kjedestrammerStatus');
    switch (status) {
        case 'OK':
            kjedestrammerElement.innerHTML = 'Kjedestrammer er i god stand.';
            break;
        case 'Bør Skiftes':
            kjedestrammerElement.innerHTML = 'Kjedestrammer bør skiftes ut.';
            break;
        case 'Defekt':
            kjedestrammerElement.innerHTML = 'Kjedestrammer er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for Wire
function setWire(status) {
    var wireElement = document.getElementById('wireStatus');
    switch (status) {
        case 'OK':
            wireElement.innerHTML = 'Wire er i god stand.';
            break;
        case 'Bør Skiftes':
            wireElement.innerHTML = 'Wire bør skiftes ut.';
            break;
        case 'Defekt':
            wireElement.innerHTML = 'Wire er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for PlnlonLager
function setPinionLager(status) {
    var pinionLagerElement = document.getElementById('pinionLagerStatus');
    switch (status) {
        case 'OK':
            pinionLagerElement.innerHTML = 'PlnlonLager er i god stand.';
            break;
        case 'Bør Skiftes':
            pinionLagerElement.innerHTML = 'PlnlonLager bør skiftes ut.';
            break;
        case 'Defekt':
            pinionLagerElement.innerHTML = 'PlnlonLager er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for KilleKjedehjul
function setKilleKjedehjul(status) {
    var killeKjedehjulElement = document.getElementById('killeKjedehjulStatus');
    switch (status) {
        case 'OK':
            killeKjedehjulElement.innerHTML = 'KilleKjedehjul er i god stand.';
            break;
        case 'Bør Skiftes':
            killeKjedehjulElement.innerHTML = 'KilleKjedehjul bør skiftes ut.';
            break;
        case 'Defekt':
            killeKjedehjulElement.innerHTML = 'KilleKjedehjul er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for HydraulikkSylinderLekkasje
function setHydraulikkSylinder(status) {
    var hydraulikkSylinderElement = document.getElementById('hydraulikkSylinderStatus');
    switch (status) {
        case 'OK':
            hydraulikkSylinderElement.innerHTML = 'HydraulikkSylinder er i god stand.';
            break;
        case 'Bør Skiftes':
            hydraulikkSylinderElement.innerHTML = 'HydraulikkSylinder bør skiftes ut.';
            break;
        case 'Defekt':
            hydraulikkSylinderElement.innerHTML = 'HydraulikkSylinder er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for SlangerSkaderLekkasje
function setSlangerSkader(status) {
    var slangerSkaderElement = document.getElementById('slangerSkaderStatus');
    switch (status) {
        case 'OK':
            slangerSkaderElement.innerHTML = 'SlangerSkader er i god stand.';
            break;
        case 'Bør Skiftes':
            slangerSkaderElement.innerHTML = 'SlangerSkader bør skiftes ut.';
            break;
        case 'Defekt':
            slangerSkaderElement.innerHTML = 'SlangerSkader er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for TestHydraulikkblokk
function setTestHydraulikkblokk(status) {
    var testHydraulikkblokkElement = document.getElementById('testHydraulikkblokkStatus');
    switch (status) {
        case 'OK':
            testHydraulikkblokkElement.innerHTML = 'TestHydraulikkblokk er i god stand.';
            break;
        case 'Bør Skiftes':
            testHydraulikkblokkElement.innerHTML = 'TestHydraulikkblokk bør skiftes ut.';
            break;
        case 'Defekt':
            testHydraulikkblokkElement.innerHTML = 'TestHydraulikkblokk er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for SkiftOljeTank
function setSkiftOljeTank(status) {
    var skiftOljeTankElement = document.getElementById('skiftOljeTankStatus');
    switch (status) {
        case 'OK':
            skiftOljeTankElement.innerHTML = 'SkiftOljeTank er i god stand.';
            break;
        case 'Bør Skiftes':
            skiftOljeTankElement.innerHTML = 'SkiftOljeTank bør skiftes ut.';
            break;
        case 'Defekt':
            skiftOljeTankElement.innerHTML = 'SkiftOljeTank er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for SkiftOljeGirboks
function setSkiftOljeGirboks(status) {
    var skiftOljeGirboksElement = document.getElementById('skiftOljeGirboksStatus');
    switch (status) {
        case 'OK':
            skiftOljeGirboksElement.innerHTML = 'SkiftOljeGirboks er i god stand.';
            break;
        case 'Bør Skiftes':
            skiftOljeGirboksElement.innerHTML = 'SkiftOljeGirboks bør skiftes ut.';
            break;
        case 'Defekt':
            skiftOljeGirboksElement.innerHTML = 'SkiftOljeGirboks er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for RingsyllingerSkiftTelnlnger
function setRingsyllinger(status) {
    var ringsyllingerElement = document.getElementById('ringsyllingerStatus');
    switch (status) {
        case 'OK':
            ringsyllingerElement.innerHTML = 'RingsyllingerSkiftTelnlnger er i god stand.';
            break;
        case 'Bør Skiftes':
            ringsyllingerElement.innerHTML = 'RingsyllingerSkiftTelnlnger bør skiftes ut.';
            break;
        case 'Defekt':
            ringsyllingerElement.innerHTML = 'RingsyllingerSkiftTelnlnger er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for BremsesylingerSkiftTelninger
function setBremsesylinger(status) {
    var bremsesylingerElement = document.getElementById('bremsesylingerStatus');
    switch (status) {
        case 'OK':
            bremsesylingerElement.innerHTML = 'BremsesylingerSkiftTelninger er i god stand.';
            break;
        case 'Bør Skiftes':
            bremsesylingerElement.innerHTML = 'BremsesylingerSkiftTelninger bør skiftes ut.';
            break;
        case 'Defekt':
            bremsesylingerElement.innerHTML = 'BremsesylingerSkiftTelninger er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for LedningsnettVinsj
function setLedningsnettVinsj(status) {
    var ledningsnettVinsjElement = document.getElementById('ledningsnettVinsjStatus');
    switch (status) {
        case 'OK':
            ledningsnettVinsjElement.innerHTML = 'LedningsnettVinsj er i god stand.';
            break;
        case 'Bør Skiftes':
            ledningsnettVinsjElement.innerHTML = 'LedningsnettVinsj bør skiftes ut.';
            break;
        case 'Defekt':
            ledningsnettVinsjElement.innerHTML = 'LedningsnettVinsj er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for SjekkTestRadio
function setSjekkTestRadio(status) {
    var sjekkTestRadioElement = document.getElementById('sjekkTestRadioStatus');
    switch (status) {
        case 'OK':
            sjekkTestRadioElement.innerHTML = 'SjekkTestRadio er i god stand.';
            break;
        case 'Bør Skiftes':
            sjekkTestRadioElement.innerHTML = 'SjekkTestRadio bør skiftes ut.';
            break;
        case 'Defekt':
            sjekkTestRadioElement.innerHTML = 'SjekkTestRadio er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for SjekkTestKnappekasse
function setSjekkTestKnappekasse(status) {
    var sjekkTestKnappekasseElement = document.getElementById('sjekkTestKnappekasseStatus');
    switch (status) {
        case 'OK':
            sjekkTestKnappekasseElement.innerHTML = 'SjekkTestKnappekasse er i god stand.';
            break;
        case 'Bør Skiftes':
            sjekkTestKnappekasseElement.innerHTML = 'SjekkTestKnappekasse bør skiftes ut.';
            break;
        case 'Defekt':
            sjekkTestKnappekasseElement.innerHTML = 'SjekkTestKnappekasse er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for XXBar
function setXXBarStatus(status) {
    var xxBarElement = document.getElementById('xxBarStatus');
    switch (status) {
        case 'OK':
            xxBarElement.innerHTML = 'XXBar er i god stand.';
            break;
        case 'Bør Skiftes':
            xxBarElement.innerHTML = 'XXBar bør skiftes ut.';
            break;
        case 'Defekt':
            xxBarElement.innerHTML = 'XXBar er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for TestVinsjAlleFunksjoner
function setTestVinsjAlleFunksjoner(status) {
    var testVinsjAlleFunksjonerElement = document.getElementById('testVinsjAlleFunksjonerStatus');
    switch (status) {
        case 'OK':
            testVinsjAlleFunksjonerElement.innerHTML = 'TestVinsjAlleFunksjoner er i god stand.';
            break;
        case 'Bør Skiftes':
            testVinsjAlleFunksjonerElement.innerHTML = 'TestVinsjAlleFunksjoner bør skiftes ut.';
            break;
        case 'Defekt':
            testVinsjAlleFunksjonerElement.innerHTML = 'TestVinsjAlleFunksjoner er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for TrekkraftKn
function setTrekkraftKn(status) {
    var trekkraftKnElement = document.getElementById('trekkraftKnStatus');
    switch (status) {
        case 'OK':
            trekkraftKnElement.innerHTML = 'TrekkraftKn er i god stand.';
            break;
        case 'Bør Skiftes':
            trekkraftKnElement.innerHTML = 'TrekkraftKn bør skiftes ut.';
            break;
        case 'Defekt':
            trekkraftKnElement.innerHTML = 'TrekkraftKn er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for BremsekraftKn
function setBremsekraftKn(status) {
    var bremsekraftKnElement = document.getElementById('bremsekraftKnStatus');
    switch (status) {
        case 'OK':
            bremsekraftKnElement.innerHTML = 'BremsekraftKn er i god stand.';
            break;
        case 'Bør Skiftes':
            bremsekraftKnElement.innerHTML = 'BremsekraftKn bør skiftes ut.';
            break;
        case 'Defekt':
            bremsekraftKnElement.innerHTML = 'BremsekraftKn er defekt.';
            break;
        default:
            break;
    }
}

// Gjør noe med verdien 'status' for Arbeidstimer
function setArbeidstimer(status) {
    var arbeidstimerElement = document.getElementById('arbeidstimerStatus');
    switch (status) {
        case 'OK':
            arbeidstimerElement.innerHTML = 'Arbeidstimer er i god stand.';
            break;
        case 'Bør Skiftes':
            arbeidstimerElement.innerHTML = 'Arbeidstimer bør skiftes ut.';
            break;
        case 'Defekt':
            arbeidstimerElement.innerHTML = 'Arbeidstimer er defekt.';
            break;
        default:
            break;
    }
}

