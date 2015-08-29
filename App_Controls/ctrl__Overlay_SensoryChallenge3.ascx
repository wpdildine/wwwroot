<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_SensoryChallenge3.ascx.cs" Inherits="App_Controls_ctrl__Overlay_SensoryChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>If the goal is to get continuous interaction, what else can Mom do to get different responses from Willie and build on them?

            <div class="row">
                <input id="q3_a" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_a">Continue to move forward toward Willie and hope that he changes his mind about her being behind the couch.
                    <em class="ans q3">If Mom continues to move forward, she doesn’t acknowledge what Willie is telling her, which is important to encourage his on-going communication. </em> </label> 
            </div>
            <div class="row">
                <input id="q3_b" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_b">Come towards him from different angles or ends of the couch.
                    <em class="ans q3 correct">Each one of Mom’s new approaches will get a different response from Willie, even if slight, and will broaden the play. </em> </label> 
            </div>
            <div class="row">
                <input id="q3_c" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_c">Pull back and wait until he invites her to join him.
                    <em class="ans q3">Willie is avoidant and unlikely to willingly invite her to join him. With an avoidant child, being gently ‘playfully obstructive’ causes the child to respond and begins the interaction.</em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>