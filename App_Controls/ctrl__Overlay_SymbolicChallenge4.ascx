<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_SymbolicChallenge4.ascx.cs" Inherits="App_Controls_ctrl__Overlay_SymbolicChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>Ricki is very good at pretend play and has a wonderful continuous flow with Mom that is nice to see. Sometimes, though, he gets going really fast. What could Mom do to help Ricki slow down when his words and movement go too fast?

            <div class="row">
                <input id="q4_a" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_a">Mom can direct the play to another theme that is less stimulating. 
                    <em class="ans q4">Mom is directing the action and taking control for Ricki. She is not following his lead. </em> </label> 
            </div>
            <div class="row">
                <input id="q4_b" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_b">Mom can add a small <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr>, for instance an obstacle for the ‘plane, ’and speak in an enticing and calming way so that he joins in her rhythm (i.e. counter-regulates) and slows down. 
                    <em class="ans q4 correct">Engaging a child in a slower rhythm (that is, counter-regulating the child’s emotions) allows the child to regroup (i.e. become regulated) on his own and experience and identify the calm feelings. </em> </label> 
            </div>
            <div class="row">
                <input id="q4_c" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_c">Mom can tell Ricki to count to 3 and slow down. 
                    <em class="ans q4">Mom is setting boundaries to slow him down rather to help him learn how to calm himself down from her and the surrounding emotional environment. </em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>