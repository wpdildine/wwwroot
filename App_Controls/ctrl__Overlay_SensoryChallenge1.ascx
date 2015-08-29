<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_SensoryChallenge1.ascx.cs" Inherits="App_Controls_ctrl__Overlay_SensoryChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>The goal for Mom is to expand the interaction with Stephen without taking control. What is the best way to do this?

            <div class="row">
                <input id="q1_a" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_a">Take Stephen’s blanket away from him to make the <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr> harder. 
                    <em class="ans q1">Pulling the blanket away takes control from Stephen.</em> </label> 
            </div>
            <div class="row">
                <input id="q1_b" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_b">Play tug-of-war with the blanket and let him win. 
                    <em class="ans q1 correct">Being playful with a tug-of-war game lets Stephen be in control, feel successful when he wins, and feel secure that he can get the blanket back if he were to lose it later in the game.  </em> </label> 
            </div>
            <div class="row">
                <input id="q1_c" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_c">Continue being a ‘doggy’ and get in his way. 
                    <em class="ans q1">Being playfully obstructive worked to get Stephen engaged initially. Continuing to do it in the same way does not expand the play. </em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>