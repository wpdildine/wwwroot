function goTo(id) {
    $.scrollTo('#' + id, 800, { 'axis': 'y' });
}
function DoNext() {

    window.open("/App_Popups/troubleshooting_nextsteps.htm", "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=0, left=0, width=800, height=900");

}
function toggleMedia(which) {

    if($("#mholder_" + which).hasClass('audio_holder'))
        if ($("#mholder_" + which).css("visibility") == "hidden")
        {

            $("#mholder_" + which).css("visibility", "visible");
            
        }
        else
        {
            //$("#mholder_" + which).css("visibility", "hidden");

        }
            
    else
        $("#mholder_" + which).fadeIn("slow");
        //$("#mholder_" + which).fadeToggle("slow", "linear");
    
}

function turnOnSection(which) {

    $("#section" + which).addClass("sect_on");

}

function switchExample(dd) {

    if (dd.value != '#')
        window.location = "challenge" + dd.value + ".aspx";

}

/* Overlay Scripts */
function showAnswers(which) {


    $('em.' + which).css('display', 'block');

}

function DoEvaluation() {

    $('.e_overlay').css('display', 'block');
    $('.e_overlay_content').fadeIn(1000);
    $.scrollTo('#header', 800, { 'axis': 'y' });

    // Based on our url, let's assign a title to our overlay
    var url = window.location.href;
    if (url.indexOf("types/sensory/challenge1.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Sensory</span>: Challenge Example 1');

    } else if (url.indexOf("types/sensory/challenge2.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Sensory</span>: Challenge Example 2');

    } else if (url.indexOf("types/sensory/challenge3.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Sensory</span>: Challenge Example 3');

    } else if (url.indexOf("types/object/challenge1.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Object</span>: Challenge Example 1');

    } else if (url.indexOf("types/object/challenge2.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Object</span>: Challenge Example 2');

    } else if (url.indexOf("types/object/challenge3.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Object</span>: Challenge Example 3');

    } else if (url.indexOf("types/symbolic/challenge1.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Symbolic</span>: Challenge Example 1');

    } else if (url.indexOf("types/symbolic/challenge2.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Symbolic</span>: Challenge Example 2');

    } else if (url.indexOf("types/symbolic/challenge3.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Symbolic</span>: Challenge Example 3');

    } else if (url.indexOf("types/symbolic/challenge4.aspx") > 0) {

        $('.e_overlay_content h1').html('<span>Symbolic</span>: Challenge Example 4');

    }

}

function HideEvaluation() {

    $('.e_overlay').css('display', 'none');
    $('.e_overlay_content').css('display', 'none');
    $.scrollTo('#footer', 800, { 'axis': 'y' });

}

function HideEvaluationAndGoBack() {

    $('.e_overlay').css('display', 'none');
    $('.e_overlay_content').css('display', 'none');
    $.scrollTo('#content', 800, { 'axis': 'y' });

}


$(document).ready(function () {

    // Let's select an element in a dropdown list if it exists
    /*var select;
    if ($('#subnav2 dl.dl_sect_3_1').css('display') == 'block')
    {

        select = $('#subnav2 dl.dl_sect_3_1 select');

    }
    else if($('#subnav2 dl.dl_sect_3_2').css('display') == 'block')
    {

        select = $('#subnav2 dl.dl_sect_3_2 select');

    }
    else if ($('#subnav2 dl.dl_sect_3_3').css('display') == 'block')
    {

        select = $('#subnav2 dl.dl_sect_3_3 select');

    }
    
    // Let's parse out the last piece of our url, which would contain something like 'challenge3.aspx'
    var url = window.location.href;
    page = url.substr(url.lastIndexOf("/") + 1, url.length - (url.lastIndexOf("/") + 1));
    
    if (select != "")
    {
        //alert(page);
        setTimeout("$('#subnav2 dl.dl_sect_3_3 select').val('2');console.log('hi')", 3000);
    }*/
});
