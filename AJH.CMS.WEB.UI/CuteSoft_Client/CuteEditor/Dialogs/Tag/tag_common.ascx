<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[Attributes]]</legend>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[CssClass]]:</td>
			<td><input type="text" id="inp_class" style="width:80px" /></td>			
			<td>&nbsp;</td>
			<td>[[Width]] :</td>
			<td><input type="text" id="inp_width" style="width:60px" onkeypress="return CancelEventIfNotDigit()" /></td>
			<td>&nbsp;</td>
			<td>[[Height]] :</td>
			<td><input type="text" id="inp_height" style="width:60px" onkeypress="return CancelEventIfNotDigit()" /></td>
		</tr>
		<tr>
			<td style='width:60px'>[[Alignment]]:</td>
			<td><select id="sel_align" style="width:80px">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="center">[[Center]]</option>
					<option value="right">[[Right]]</option>
				</select>
			</td>
			<td>&nbsp;</td>
			<td>[[Text-Align]]:</td>
			<td><select id="sel_textalign">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="center">[[Center]]</option>
					<option value="right">[[Right]]</option>
					<option value="justify">[[Justify]]</option>
				</select>
			</td>
			<td>&nbsp;</td>
			<td>
				[[Float]]:
			</td>
			<td><select id="sel_float">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="right">[[Right]]</option>
				</select>
			</td>
		</tr>
		<tr>
			<td style='width:60px'>
				[[ForeColor]]</td>
			<td>
<input autocomplete="off" type="text" id="inp_forecolor" name="inp_forecolor" size="7" style="WIDTH:57px" />
<img alt="" id="img_forecolor" src="Load.ashx?type=image&file=colorpicker.gif" style='vertical-align:inherit;behavior:url(Load.ashx?type=htc&file=ColorPicker.htc)'	/>
			</td>
			<td>&nbsp;</td>
			<td>[[BackColor]]</td>
			<td colspan="4">
<input autocomplete="off" type="text" id="inp_backcolor" name="inp_backcolor" size="7" style="WIDTH:57px" />
<img alt="" id="img_backcolor" src="Load.ashx?type=image&file=colorpicker.gif" style='vertical-align:inherit;behavior:url(Load.ashx?type=htc&file=ColorPicker.htc)'	 />
			</td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[title]]:</td>
			<td>
				<textarea id="inp_tooltip" rows="3" cols="20" style="width:320px"></textarea>
			</td>
		</tr>
	</table>
</fieldset>
<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_Tag_Common.js"></script>

