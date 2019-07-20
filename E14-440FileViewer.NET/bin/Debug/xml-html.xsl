<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output doctype-system="about:legacy-compat" method="html" encoding="utf-8"/>
  <xsl:template match="/">
    <html>
		<head>
			<title>Channels metadata</title>
		</head>
		<body>
			<div id="frequency">
				frequency: <xsl:value-of select="boundle/frequency"/>
			</div>
		</body>
	</html>			  
  </xsl:template>
</xsl:stylesheet>