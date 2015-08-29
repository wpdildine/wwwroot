<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_SymbolicChallenge3.ascx.cs" Inherits="App_Controls_ctrl__Overlay_SymbolicChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>Grace is beginning to sing the ‘nonsense song’ and Mom wants to get into a better back-and-forth rhythm. What can she do? 

            <div class="row">
                <input id="q3_a" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_a">Make up words for the song that make more sense.
                    <em class="ans q3">Mom would be decreasing Grace’s creativity and her motivation to participate. </em> </label> 
            </div>
            <div class="row">
                <input id="q3_b" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_b">Choose a song that is different than Grace’s.
                    <em class="ans q3">This would take the control away from Grace and may be too challenging. </em> </label> 
            </div>
            <div class="row">
                <input id="q3_c" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_c">Come up with her own silly lyrics and see how Grace responds. 
                    <em class="ans q3 correct">This shows Grace that Mom is there to have fun and follow her lead while gently expanding the activity. </em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>