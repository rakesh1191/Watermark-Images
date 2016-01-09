<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jQueryViewer.aspx.cs" Inherits="jQueryViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.4.2.min.js"></script>
<script src="jquery.swfobject.1-1-1.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script>
flashMovie = null;

$(document).ready(
	function () {
		flashMovie = $('#flashInteract .movie');

		flashMovie.flash(
			{
				swf: '<%=swfFileName %>',
				width: 800,
				height: 800,
				play: false,
				flashvars: {
					message: 'I come from Flash.'
				},
			}
		);
	}
);

function play() {
	flashMovie.flash(
		function() {
			this.Play();
		}
	);
}

function pause() {
	flashMovie.flash(
		function() {
			this.StopPlay();
		}
	);
}

function firstFrame() {
	flashMovie.flash(
		function() {
			this.GotoFrame(0);
		}
	);
}

function lastFrame() {
	flashMovie.flash(
		function() {
			this.GotoFrame(9);
		}
	);
}

function prevFrame() {
	flashMovie.flash(
		function() {
			var currentFrame = this.TGetProperty('/', 4),
				previousFrame = parseInt(currentFrame) - 2;

			if (previousFrame < 0) {
				previousFrame = 9;
			}

			this.GotoFrame(previousFrame);
		}
	);
}

function nextFrame() {
	flashMovie.flash(
		function() {
			var currentFrame = this.TGetProperty('/', 4),
				nextFrame = parseInt(currentFrame);

			if (nextFrame >= 10) {
				nextFrame = 0;
			}

			this.GotoFrame(nextFrame);
		}
	);
}

function sendToFlash() {
	flashMovie.flash(
		function() {
			this.SetVariable('/:message', document.getElementById('data').value);
		}
	);
}

function getFromFlash() {
	flashMovie.flash(
		function() {
			document.getElementById('data').value = this.GetVariable('/:message');
		}
	);
}
</script>

<div id="flashInteract">
	<div class="movie"></div>

	<p style="font-family: arial;">
		<input type="button" onclick="firstFrame();" value="<<" />
		<input type="button" onclick="prevFrame();" value="<" />
		<input type="button" onclick="play();" value="PLAY" />
		<input type="button" onclick="pause();" value="PAUSE" />
		<input type="button" onclick="nextFrame();" value=">" />
		<input type="button" onclick="lastFrame();" value=">>" />
	</p>

	<p>
		<input type="text" value="I come from javascript." size="20" onfocus="this.select();" id="data" /> 
		<input type="button" onclick="sendToFlash();" value="Send to Flash" />
		<input type="button" onclick="getFromFlash();" value="Get from Flash" />
	</p>
    <p>
                                <asp:FileUpload ID="fUpload" runat="server" Width="300px" />
	</p>
    <p>
		<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="View" />
	</p>
</div>
    </div>
    </form>
</body>
</html>
