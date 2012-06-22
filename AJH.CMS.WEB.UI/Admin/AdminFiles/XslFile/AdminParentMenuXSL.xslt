<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:UserControl="CMS:UserControl">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <xsl:call-template name="CreateMenu">
    </xsl:call-template>
  </xsl:template>
  <xsl:template name="CreateMenu">
    <div class="top-menu">
      <xsl:for-each select="Menus/Menu">
        <a id="hrefParentModule{@Id}" href="{UserControl:ResolveUrl(@Url)}?ModuleID={@Id}" class="top-menu-item tmi2">
          <xsl:value-of select="@Name"/>
        </a>
      </xsl:for-each>
    </div>
  </xsl:template>
</xsl:stylesheet>