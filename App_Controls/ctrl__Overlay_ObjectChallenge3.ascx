<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_ObjectChallenge3.ascx.cs" Inherits="App_Controls_ctrl__Overlay_ObjectChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>Because of Amberlee’s motor and visual processing difficulties, it can be hard to keep interaction going. A few times she seems to lose focus. What could her parents do so that didn’t happen?

            <div class="row">
                <input id="q3_a" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_a">Always let her see where they put the toy. 
                    <em class="ans q3 correct">Amberlee is able to find something out of sight if she has seen the hiding place. Following this course lets her improve her visual-spatial processing. Constantly changing the hiding place (while letting her watch) lets her experiment with looking in different parts of the room. It <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr>s at just the right level and helps to keep the rhythm of the game.</em> </label> 
            </div>
            <div class="row">
                <input id="q3_b" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_b">Always hide the toy in plain sight.
                    <em class="ans q3">Hiding the toy in plain sight is not challenging for Amberlee and doesn’t expand the play or broaden her responses or her visual-spatial processing.</em> </label> 
            </div>
            <div class="row">
                <input id="q3_c" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_c">Always hide the toy in the same place.
                    <em class="ans q3">Not varying the hiding place does not increase the <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr> for her.</em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>