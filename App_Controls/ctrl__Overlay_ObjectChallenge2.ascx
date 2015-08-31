<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_ObjectChallenge2.ascx.cs" Inherits="App_Controls_ctrl__Overlay_ObjectChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>Because of Caroline’s motor delays, what could Mom do to let her have a quicker and more consistent response? 

            <div class="row">
                <input id="q2_a" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_a">Move Caroline’s body to show her how to get the toy.
                    <em class="ans q2">Moving her body takes control away from Caroline and doesn’t let her express her feelings and follow her interest in getting to the toy. It also inhibits development of her motor system.</em> </label> 
            </div>
            <div class="row">
                <input id="q2_b" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_b">Keep the toy in one place so that it is easier for Caroline to get it.
                    <em class="ans q2">Keeping the toy fixed doesn’t <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr> Caroline. </em> </label> 
            </div>
            <div class="row">
                <input id="q2_c" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_c">Move the toy very slowly and in small increments.
                    <em class="ans q2 correct">Slow and gradual movement gives Caroline a chance to make a decision about what she wants to do and how she can do it comfortably. Because of her motor delays, fast movement can be too difficult for her to respond to.</em> </label>
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>