<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_SensoryChallenge2.ascx.cs" Inherits="App_Controls_ctrl__Overlay_SensoryChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>Even though Mom is concerned about Gary’s language, he also needs to work on his movement. What is the best way to do this? 

            <div class="row">
                <input id="q2_a" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_a">Pause and then approach slowly to tickle.
                    <em class="ans q2 correct">This approach gives Gary an opportunity to respond in his own way. Whatever his response is, it is the right one. There is no wrong one (except doing something to hurt Mom.)  Mom’s response to Gary should reinforce his gestures and words and expand the play. </em> </label> 
            </div>
            <div class="row">
                <input id="q2_b" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_b">Tell him which option to choose.
                    <em class="ans q2">Giving him the answer solves the problem for him and doesn’t give him a chance to think for himself. </em> </label> 
            </div>
            <div class="row">
                <input id="q2_c" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_c">Continue to tickle him.
                    <em class="ans q2">If Gary isn’t asked what he wants, he isn’t a partner in the play and can’t direct the action to suit his interests and needs. Thus he isn’t communicating and thinking.</em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>