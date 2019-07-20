<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output doctype-system="about:legacy-compat" method="html" encoding="utf-8"/>
  <xsl:template match="/">
    <html>
		<head>
			<title>Channels metadata</title>
		</head>
		<body>
			<h1>Channels metadata</h1>
			<div id="frequency">
				frequency: <xsl:value-of select="bundle/frequency"/>
			</div>
			<table>
			  <tr>
				<th>number</th>
				<th>amplification</th> 
				<th>max value</th>
			  </tr>
			  <xsl:apply-templates select="bundle/channels/channel" />
			</table>
		</body>
	</html>			  
  </xsl:template>
  <xsl:template match="channel">
	  <tr>
		<td><xsl:value-of select="./@number" /></td>
		<td><xsl:value-of select="./amplification" /></td> 
		<td><xsl:value-of select="./max" /></td>
	  </tr>
  </xsl:template>
</xsl:stylesheet>