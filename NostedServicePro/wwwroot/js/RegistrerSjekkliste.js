



// DENNE BRUKES IKKE!!!!!!





function setBremserStatus(status) {
    // Finn det relevante HTML-elementet for Bremser
    var bremserElement = document.getElementById('bremserStatus');

    // Oppdater grensesnittet basert p� valgt status
    switch (status) {
        case 'OK':
            bremserElement.innerHTML = 'Bremser er i god stand.';
            break;
        case 'B�r Skiftes':
            bremserElement.innerHTML = 'Bremser b�r skiftes ut.';
            break;
        case 'Defekt':
            bremserElement.innerHTML = 'Bremser er defekte.';
            break;
        default:
            // H�ndter andre tilfeller hvis n�dvendig
            break;
    }
}

// Legg til dette i din RegistrerSjekkliste.js-fil

// Gj�r noe med verdien 'status' for LagerTrommel
function setLagerTrommel(status) {
    // Finn det relevante HTML-elementet for LagerTrommel
    var lagerTrommelElement = document.getElementById('lagerTrommelStatus');

    // Oppdater grensesnittet basert p� valgt status
    switch (status) {
        case 'OK':
            lagerTrommelElement.innerHTML = 'LagerTrommel er i god stand.';
            break;
        case 'B�r Skiftes':
            lagerTrommelElement.innerHTML = 'LagerTrommel b�r skiftes ut.';
            break;
        case 'Defekt':
            lagerTrommelElement.innerHTML = 'LagerTrommel er defekt.';
            break;
        default:
            // H�ndter andre tilfeller hvis n�dvendig
            break;
    }
}


// Gj�r noe med verdien 'status' for PTOOpplagring
function setPTOOpplagring(status) {
    // Finn det relevante HTML-elementet for PTOOpplagring
    var ptoOpplagringElement = document.getElementById('ptoOpplagringStatus');

    // Oppdater grensesnittet basert p� valgt status
    switch (status) {
        case 'OK':
            ptoOpplagringElement.innerHTML = 'PTOOpplagring er i god stand.';
            break;
        case 'B�r Skiftes':
            ptoOpplagringElement.innerHTML = 'PTOOpplagring b�r skiftes ut.';
            break;
        case 'Defekt':
            ptoOpplagringElement.innerHTML = 'PTOOpplagring er defekt.';
            break;
        default:
            // H�ndter andre tilfeller hvis n�dvendig
            break;
    }
}

// Gj�r noe med verdien 'status' for Kjedestrammer
function setKjedestrammer(status) {
    var kjedestrammerElement = document.getElementById('kjedestrammerStatus');
    switch (status) {
        case 'OK':
            kjedestrammerElement.innerHTML = 'Kjedestrammer er i god stand.';
            break;
        case 'B�r Skiftes':
            kjedestrammerElement.innerHTML = 'Kjedestrammer b�r skiftes ut.';
            break;
        case 'Defekt':
            kjedestrammerElement.innerHTML = 'Kjedestrammer er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for Wire
function setWire(status) {
    var wireElement = document.getElementById('wireStatus');
    switch (status) {
        case 'OK':
            wireElement.innerHTML = 'Wire er i god stand.';
            break;
        case 'B�r Skiftes':
            wireElement.innerHTML = 'Wire b�r skiftes ut.';
            break;
        case 'Defekt':
            wireElement.innerHTML = 'Wire er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for PlnlonLager
function setPinionLager(status) {
    var pinionLagerElement = document.getElementById('pinionLagerStatus');
    switch (status) {
        case 'OK':
            pinionLagerElement.innerHTML = 'PlnlonLager er i god stand.';
            break;
        case 'B�r Skiftes':
            pinionLagerElement.innerHTML = 'PlnlonLager b�r skiftes ut.';
            break;
        case 'Defekt':
            pinionLagerElement.innerHTML = 'PlnlonLager er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for KilleKjedehjul
function setKilleKjedehjul(status) {
    var killeKjedehjulElement = document.getElementById('killeKjedehjulStatus');
    switch (status) {
        case 'OK':
            killeKjedehjulElement.innerHTML = 'KilleKjedehjul er i god stand.';
            break;
        case 'B�r Skiftes':
            killeKjedehjulElement.innerHTML = 'KilleKjedehjul b�r skiftes ut.';
            break;
        case 'Defekt':
            killeKjedehjulElement.innerHTML = 'KilleKjedehjul er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for HydraulikkSylinderLekkasje
function setHydraulikkSylinder(status) {
    var hydraulikkSylinderElement = document.getElementById('hydraulikkSylinderStatus');
    switch (status) {
        case 'OK':
            hydraulikkSylinderElement.innerHTML = 'HydraulikkSylinder er i god stand.';
            break;
        case 'B�r Skiftes':
            hydraulikkSylinderElement.innerHTML = 'HydraulikkSylinder b�r skiftes ut.';
            break;
        case 'Defekt':
            hydraulikkSylinderElement.innerHTML = 'HydraulikkSylinder er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for SlangerSkaderLekkasje
function setSlangerSkader(status) {
    var slangerSkaderElement = document.getElementById('slangerSkaderStatus');
    switch (status) {
        case 'OK':
            slangerSkaderElement.innerHTML = 'SlangerSkader er i god stand.';
            break;
        case 'B�r Skiftes':
            slangerSkaderElement.innerHTML = 'SlangerSkader b�r skiftes ut.';
            break;
        case 'Defekt':
            slangerSkaderElement.innerHTML = 'SlangerSkader er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for TestHydraulikkblokk
function setTestHydraulikkblokk(status) {
    var testHydraulikkblokkElement = document.getElementById('testHydraulikkblokkStatus');
    switch (status) {
        case 'OK':
            testHydraulikkblokkElement.innerHTML = 'TestHydraulikkblokk er i god stand.';
            break;
        case 'B�r Skiftes':
            testHydraulikkblokkElement.innerHTML = 'TestHydraulikkblokk b�r skiftes ut.';
            break;
        case 'Defekt':
            testHydraulikkblokkElement.innerHTML = 'TestHydraulikkblokk er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for SkiftOljeTank
function setSkiftOljeTank(status) {
    var skiftOljeTankElement = document.getElementById('skiftOljeTankStatus');
    switch (status) {
        case 'OK':
            skiftOljeTankElement.innerHTML = 'SkiftOljeTank er i god stand.';
            break;
        case 'B�r Skiftes':
            skiftOljeTankElement.innerHTML = 'SkiftOljeTank b�r skiftes ut.';
            break;
        case 'Defekt':
            skiftOljeTankElement.innerHTML = 'SkiftOljeTank er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for SkiftOljeGirboks
function setSkiftOljeGirboks(status) {
    var skiftOljeGirboksElement = document.getElementById('skiftOljeGirboksStatus');
    switch (status) {
        case 'OK':
            skiftOljeGirboksElement.innerHTML = 'SkiftOljeGirboks er i god stand.';
            break;
        case 'B�r Skiftes':
            skiftOljeGirboksElement.innerHTML = 'SkiftOljeGirboks b�r skiftes ut.';
            break;
        case 'Defekt':
            skiftOljeGirboksElement.innerHTML = 'SkiftOljeGirboks er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for RingsyllingerSkiftTelnlnger
function setRingsyllinger(status) {
    var ringsyllingerElement = document.getElementById('ringsyllingerStatus');
    switch (status) {
        case 'OK':
            ringsyllingerElement.innerHTML = 'RingsyllingerSkiftTelnlnger er i god stand.';
            break;
        case 'B�r Skiftes':
            ringsyllingerElement.innerHTML = 'RingsyllingerSkiftTelnlnger b�r skiftes ut.';
            break;
        case 'Defekt':
            ringsyllingerElement.innerHTML = 'RingsyllingerSkiftTelnlnger er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for BremsesylingerSkiftTelninger
function setBremsesylinger(status) {
    var bremsesylingerElement = document.getElementById('bremsesylingerStatus');
    switch (status) {
        case 'OK':
            bremsesylingerElement.innerHTML = 'BremsesylingerSkiftTelninger er i god stand.';
            break;
        case 'B�r Skiftes':
            bremsesylingerElement.innerHTML = 'BremsesylingerSkiftTelninger b�r skiftes ut.';
            break;
        case 'Defekt':
            bremsesylingerElement.innerHTML = 'BremsesylingerSkiftTelninger er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for LedningsnettVinsj
function setLedningsnettVinsj(status) {
    var ledningsnettVinsjElement = document.getElementById('ledningsnettVinsjStatus');
    switch (status) {
        case 'OK':
            ledningsnettVinsjElement.innerHTML = 'LedningsnettVinsj er i god stand.';
            break;
        case 'B�r Skiftes':
            ledningsnettVinsjElement.innerHTML = 'LedningsnettVinsj b�r skiftes ut.';
            break;
        case 'Defekt':
            ledningsnettVinsjElement.innerHTML = 'LedningsnettVinsj er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for SjekkTestRadio
function setSjekkTestRadio(status) {
    var sjekkTestRadioElement = document.getElementById('sjekkTestRadioStatus');
    switch (status) {
        case 'OK':
            sjekkTestRadioElement.innerHTML = 'SjekkTestRadio er i god stand.';
            break;
        case 'B�r Skiftes':
            sjekkTestRadioElement.innerHTML = 'SjekkTestRadio b�r skiftes ut.';
            break;
        case 'Defekt':
            sjekkTestRadioElement.innerHTML = 'SjekkTestRadio er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for SjekkTestKnappekasse
function setSjekkTestKnappekasse(status) {
    var sjekkTestKnappekasseElement = document.getElementById('sjekkTestKnappekasseStatus');
    switch (status) {
        case 'OK':
            sjekkTestKnappekasseElement.innerHTML = 'SjekkTestKnappekasse er i god stand.';
            break;
        case 'B�r Skiftes':
            sjekkTestKnappekasseElement.innerHTML = 'SjekkTestKnappekasse b�r skiftes ut.';
            break;
        case 'Defekt':
            sjekkTestKnappekasseElement.innerHTML = 'SjekkTestKnappekasse er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for XXBar
function setXXBarStatus(status) {
    var xxBarElement = document.getElementById('xxBarStatus');
    switch (status) {
        case 'OK':
            xxBarElement.innerHTML = 'XXBar er i god stand.';
            break;
        case 'B�r Skiftes':
            xxBarElement.innerHTML = 'XXBar b�r skiftes ut.';
            break;
        case 'Defekt':
            xxBarElement.innerHTML = 'XXBar er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for TestVinsjAlleFunksjoner
function setTestVinsjAlleFunksjoner(status) {
    var testVinsjAlleFunksjonerElement = document.getElementById('testVinsjAlleFunksjonerStatus');
    switch (status) {
        case 'OK':
            testVinsjAlleFunksjonerElement.innerHTML = 'TestVinsjAlleFunksjoner er i god stand.';
            break;
        case 'B�r Skiftes':
            testVinsjAlleFunksjonerElement.innerHTML = 'TestVinsjAlleFunksjoner b�r skiftes ut.';
            break;
        case 'Defekt':
            testVinsjAlleFunksjonerElement.innerHTML = 'TestVinsjAlleFunksjoner er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for TrekkraftKn
function setTrekkraftKn(status) {
    var trekkraftKnElement = document.getElementById('trekkraftKnStatus');
    switch (status) {
        case 'OK':
            trekkraftKnElement.innerHTML = 'TrekkraftKn er i god stand.';
            break;
        case 'B�r Skiftes':
            trekkraftKnElement.innerHTML = 'TrekkraftKn b�r skiftes ut.';
            break;
        case 'Defekt':
            trekkraftKnElement.innerHTML = 'TrekkraftKn er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for BremsekraftKn
function setBremsekraftKn(status) {
    var bremsekraftKnElement = document.getElementById('bremsekraftKnStatus');
    switch (status) {
        case 'OK':
            bremsekraftKnElement.innerHTML = 'BremsekraftKn er i god stand.';
            break;
        case 'B�r Skiftes':
            bremsekraftKnElement.innerHTML = 'BremsekraftKn b�r skiftes ut.';
            break;
        case 'Defekt':
            bremsekraftKnElement.innerHTML = 'BremsekraftKn er defekt.';
            break;
        default:
            break;
    }
}

// Gj�r noe med verdien 'status' for Arbeidstimer
function setArbeidstimer(status) {
    var arbeidstimerElement = document.getElementById('arbeidstimerStatus');
    switch (status) {
        case 'OK':
            arbeidstimerElement.innerHTML = 'Arbeidstimer er i god stand.';
            break;
        case 'B�r Skiftes':
            arbeidstimerElement.innerHTML = 'Arbeidstimer b�r skiftes ut.';
            break;
        case 'Defekt':
            arbeidstimerElement.innerHTML = 'Arbeidstimer er defekt.';
            break;
        default:
            break;
    }
}

